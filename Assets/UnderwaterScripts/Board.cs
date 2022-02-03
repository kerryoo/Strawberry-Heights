using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DRAFT

namespace Graphs {
    public class Board
    {
        // TODO: start and end position vectors
        PipeGraph graph; // operate on graph
        PipeGraph origGraph;
        int level;

        //TODO: constructor

        public void ResetLevel()
        {
            graph = origGraph;
        }

        // randomly spawn obstacles on the board according to difficulty level
        public void SpawnObstacles()
        {
            // put obstacles on origGraph
            graph = origGraph;
        }

        // a further abstraction that calls resetBoard and waterFlow
        public void OnComplete()
        {
            waterFlow();
            level += 1;
            resetBoard();
            origGraph = new PipeGraph();
        }

        // checks if there’s a valid path and if so, calls onComplete
        public void Submit()
        {
            if (graph.checkValid())
            {
                OnComplete();
            }
            else
            {
                OnFail();
            }
        }

        // if submission fails, show the water flow fail
        public void OnFail()
        {

        }

        //animation of water flowing onComplete
        public void waterFlow()
        {

        }

        //resetsBoard to a difficulty corresponding to level; called by onComplete
        public void resetBoard()
        {
            SpawnObstacles();
        }
    }
}
