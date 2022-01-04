using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeNode
{
    string shape; // 4-digit binary indicating the shape of the pipe (int values 0000 to 1111)
    PipeNode[] neighbours; // array of node representing North, East, South, West nieghbours

    // CONSTRUCTOR
    public PipeNode(string shape)
    {
        this.shape = shape;
        neighbours = new PipeNode[4];
    }

    // PROPERTIES
    // Get shape of node
    public string Shape
    {
        get { return shape; }
    }

    // Get read-only list of neighbours of the node
    public PipeNode[] Neighbours
    {
        get { return neighbours; }
    }

    //METHODS
    // add new neightbour to specified direction (N = 0, E = 1, S = 2, W = 3)
    public void AddNeightbour(PipeNode neighbour, int direction)
    {
        neighbours[direction] = neighbour;
    }

    // remove all neighbours
    public void RemoveAllNeighbours()
    {
        for(int i = 0; i < neighbours.Length; i++)
        {
            neighbours[i] = null;
        }
    }

    //rotate pipe by modifying shapes
    public void RotateRight()
    {
        RemoveAllNeighbours();
        shape = shape[3] + shape.Substring(0,3);
    }

    public void RotateLeft()
    {
        RemoveAllNeighbours();
        shape = shape.Substring(1, 4) + shape[0];
    }
}