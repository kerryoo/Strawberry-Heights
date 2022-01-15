using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Graphs
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    };

    public class PipeGraph
    {
        List<PipeNode> nodes = new List<PipeNode>();
        // how to note positions?
        Pair<int, int> startPos;
        Pair<int, int> endPos;

        public PipeGraph(Pair<int, int> s, Pair<int, int> f)
        {
            this.startPos = s;
            this.endPos = f;
        }

        public IList<PipeNode> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }

        public bool Connect(int id1, int id2, int dir)
        {
            PipeNode node1 = Find(id1);
            PipeNode node2 = Find(id2);

            if(node1 == null || node2 == null)
            {
                return false;
            }
            else if(node1.Neighbors.Contains(node2))
            {
                // already exists
                return false;
            }
            else
            {
                return node1.AddNeighbor(node2, dir) && 
                    node2.AddNeighbor(node1, (dir+2)%4);
            }
        }

        /// <summary>
        /// Finds the graph node with the given value
        /// </summary>
        /// <returns>graph node or null if not found</returns>
        public PipeNode Find(int id)
        {
            foreach (PipeNode node in nodes)
            {
                if (node.Id.Equals(id))
                {
                    return node;
                }
            }
            return null;
        }

        public bool RemoveNode(int id)
        {
            PipeNode removeNode = Find(id);

            if(removeNode == null)
            {
                return false;
            }
            else
            {
                nodes.Remove(removeNode);

                foreach (PipeNode node in nodes)
                {
                    node.RemoveNeighbor(removeNode);
                }

                return true;
            }
        }

        public bool RemoveEdge(int id1, int id2)
        {
            PipeNode node1 = Find(id1);
            PipeNode node2 = Find(id2);

            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if (!node1.Neighbors.Contains(node2))
            {
                // does not exist
                return false;
            }
            else
            {
                node1.RemoveNeighbor(node2);
                node2.RemoveNeighbor(node1);
                return true;
            }
        }

        /*
        public bool AddNode(PipeNode newPipe)
        {
            for (int i = 0; i < 4; ++i)
            {
                if (cur.Shape[i] == 1 && newPipe.Shape[(i + 2) % 4] == 1)
                {
                    // TODO: how to determine which openning to connect?
                    // How to go back to previous pipe if need to?
                    // need memory of all pipe in the graph? use matrix or list to connect?
                    // is 4 direction pipes still needed?
                    newPipe.AddNeighbor(newPipe, (i + 2) % 4);
                    cur.Shape[i] = 0;
                    newPipe.Shape[(i + 2) % 4] = 0;
                    cur = newPipe;
                    return true;
                }
            }

            // invalid placement
            return false;
        }

        public bool removeLastPlaced()
        {
            PipeNode tmp = cur;
            // which one to go back to as cur?

            for (int i = 0; i < 4; ++i)
            {
                if (tmp.Shape[i] == 0 && tmp.Neighbours[i] != null)
                {
                    cur = tmp.Neighbours[i];
                    cur.Shape[(i + 2) % 4] = 0;
                    cur.Neighbours[(i + 2) % 4] = null;
                    // how to get the node off the grid?
                    return true;
                }
            }

            // nothing to remove here
            return false;
        }

        public bool removeNode(PipeNode rm)
        {

        }

        public bool checkValid()
        {

        }
        */
    }
}
