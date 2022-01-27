using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DRAFT
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

    // randomly spawn obstacles on the board
    public void SpawnObstacles()
    {
        // put obstacles on origGraph
        graph = origGraph;
    }

    // a further abstraction that calls reset board and spawn obstacles
    public void OnComplete()
    {
        level += 1;
        origGraph = new PipeGraph;
        SpawnObstacles();

    }

    // checks if there’s a valid path and if so, makes a water flow
    // animation and calls onComplete
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
}
