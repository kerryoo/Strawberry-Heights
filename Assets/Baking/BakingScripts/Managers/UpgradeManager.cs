using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    //[SerializeField] Material[] wallMaterial;
    [SerializeField] Texture2D[] wallTextures;
    //saved Data
    [SerializeField] int wallIndex;

    [SerializeField] GameObject[] floors;
    [SerializeField] Texture2D[] floorTextures;
    //saved Data
    [SerializeField] int floorIndex;
    HashSet<int> floorUnlockedTextures = new HashSet<int>();

    [SerializeField] BakeryManager bakeryManager;
    [SerializeField] TestManager tester;


    private void Start()
    {
        tester.GetComponent<TestManager>().upgradeEvent.AddListener(renderWall);
        tester.GetComponent<TestManager>().upgradeEvent.AddListener(renderFloor);
    }

    private void renderWall(int id)
    {
        Debug.Log("renderWall");
        wallIndex = id;
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material.SetTexture("_MainTex", wallTextures[wallIndex]);
            //wall.GetComponent<MeshRenderer>().material = wallMaterial[wallIndex];
            wall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(5, 5);
        }
    }

    private void renderFloor(int id)
    {
        Debug.Log("renderFloor");
        floorIndex = id;
        foreach (GameObject floor in floors)
        {
            floor.GetComponent<Renderer>().material.SetTexture("_MainTex", floorTextures[floorIndex]);
            floor.GetComponent<Renderer>().material.mainTextureScale = new Vector2(5, 5);
        }
    }

    public void buyWall(int wallID)
    {
        // same as floor   
    }

    public void buyFloor(int floorID)
    {
        floorUnlockedTextures.Add(floorID);
    }

    public void setWall (int wallID)
    {
        // same as floor
    }

    public void setFloor(int floorID)
    {
        if (floorUnlockedTextures.Contains(floorID)) {
            floorIndex = floorID;
            renderFloor(floorID);
        }
        else
        {
            Debug.Log("Floor not unlocked yet");
        }
    }
}
