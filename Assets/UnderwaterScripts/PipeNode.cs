using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNode
{
    string shape; // 4-digit binary indicating the shape of the pipe
    List<PipeNode> neighbours; // list of node representing North, East, South, West nieghbours

    // CONSTRUCTOR
    public PipeNode(string shape)
    {
        this.shape = shape;
        neighbours = new List<PipeNode>(new PipeNode[4]);
    }

    // PROPERTIES
    // Get shape of node
    public string Shape
    {
        get { return shape; }
    }

    // Get read-only list of neighbours of the node
    public IList<PipeNode> Neighbours
    {
        get { return neighbours.AsReadOnly(); }
    }

    //METHODS
    public void AddNeightbour(PipeNode neighbour, int direction)
    {
        // add new neightbour to specified direction
    }

    public void RemoveAllNeighbours()
    {
        // remove all neighbours
    }


    public void RotateRight(int amount)
    {
        //rotate pipe by modifying shapes
    }
}