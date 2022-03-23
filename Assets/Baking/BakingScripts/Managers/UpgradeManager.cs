using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    //[SerializeField] Material[] wallMaterial;
    [SerializeField] Texture2D[] wallTextures;
    //saved Data
    int wallIndex = 0;

    [SerializeField] GameObject[] floors;
    [SerializeField] Texture2D[] floorTextures;
    //saved Data
    int floorIndex = 0;
    HashSet<int> floorUnlockedTextures = new HashSet<int>();

    [SerializeField] BakeryManager bakeryManager;
    

    private void Start()
    {
        renderWall();
        renderFloor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            renderWall();
        }
    }

    private void renderWall()
    {
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().material.SetTexture("_MainTex", wallTextures[wallIndex]);
            //wall.GetComponent<MeshRenderer>().material = wallMaterial[wallIndex];
            wall.GetComponent<Renderer>().material.mainTextureScale = new Vector2(5, 5);
        }
    }

    private void renderFloor()
    {
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
            renderFloor();
        }
        else
        {
            Debug.Log("Floor not unlocked yet");
        }
    }
}
