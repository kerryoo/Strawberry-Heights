using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PipeNode : MonoBehaviour
{
    [SerializeField] List<GameObject> connectPoints;

    [SerializeField] int id;

    bool beingHeld;
    string shape; // 4-digit binary indicating the shape of the pipe (int values 0000 to 1111)
    PipeNode[] neighbors; // array of node representing North, East, South, West nieghbours

    private void Update()
    {
        GetConnectPointPos();
    }

    // CONSTRUCTOR
    public PipeNode(int id, string shape)
    {
        this.id = id;
        this.shape = shape;
        neighbors = new PipeNode[4];
    }

    // PROPERTIES
    // Get ID
    public int Id
    {
        get { return id; }
    }

    // Get shape of node
    public string Shape
    {
        get { return shape; }
    }

    // Get read-only list of neighbours of the node
    public PipeNode[] Neighbors
    {
        get { return neighbors; }
    }

    //METHODS
    // add new neightbour to specified direction (N = 0, E = 1, S = 2, W = 3)
    public bool AddNeighbor(PipeNode neighbor, int direction)
    {
        // check valid here
        if (shape[direction] == 1 && neighbor.shape[(direction + 2) % 4] == 1
            && neighbors[direction] == null && neighbor.neighbors[(direction + 2) % 4] == null)
        {
            neighbors[direction] = neighbor;
            return true;
        }

        return false;
    }

    // remove a node
    public bool RemoveNeighbor(PipeNode neighbor)
    {
        for(int i =0; i<neighbors.Length; ++i)
        {
            if(neighbors[i] == neighbor)
            {
                neighbors[i] = null;
                return true;
            }
        }
        return false;
    }

    // remove all neighbours
    public void RemoveAllNeighbors()
    {
        for (int i = 0; i < neighbors.Length; i++)
        {
            neighbors[i] = null;
        }
    }

    //rotate pipe by modifying shapes
    public void RotateRight()
    {
        RemoveAllNeighbors();
        shape = shape[3] + shape.Substring(0, 3);
    }

    public void RotateLeft()
    {
        RemoveAllNeighbors();
        shape = shape.Substring(1, 4) + shape[0];
    }

    private void GetConnectPointPos()
    {
        foreach (GameObject connectPoint in connectPoints)
        {
            Debug.Log(connectPoint.transform.position);
        }
    }
}
