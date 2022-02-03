using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Graphs
{

    public class PipeGraph
    {
        List<PipeNode> nodes = new List<PipeNode>();
        // how to note positions?
        PipeNode startPos;
        PipeNode endPos;

        public PipeGraph(PipeNode start, PipeNode end)
        {
            this.startPos = start;
            this.endPos = end;
        }

        public IList<PipeNode> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }

        public bool Connect(int id1, int id2, int dir)
        {
            PipeNode node1 = Find(id1);
            PipeNode node2 = Find(id2);

            if (node1 == null || node2 == null)
            {
                return false;
            }
            else if (node1.Neighbors.Contains(node2))
            {
                // already exists
                return false;
            }
            else
            {
                return node1.AddNeighbor(node2, dir) &&
                    node2.AddNeighbor(node1, (dir + 2) % 4);
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

            if (removeNode == null)
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
        public bool checkValid()
        { 
            foreach (PipeNode node in nodes)
            {
                int count = 0;
                foreach (char c in node.Shape)
                {
                    if(c == '1')
                    {
                        ++count;
                    }
                }
                
                if(count != node.Neighbors.Length)
                {
                    return false;
                }
            }

            return dfs(startPos);
        }

        HashSet<PipeNode> visited;
        public bool dfs(PipeNode node)
        {
            if(node.Id == 1)
            {
                return true;
            }

            if(!visited.Contains(node))
            {
                visited.Add(node);
                if(dfs(node.Neighbors[0]) || dfs(node.Neighbors[1]) || dfs(node.Neighbors[2]) || dfs(node.Neighbors[3]))
                {
                    return true;
                }

                visited.Remove(node);
            }

            return false;
        }

    }
}
