using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class Dessert : MonoBehaviour
{
    [Serializable]
    public struct Combinations
    {
        public int[] DessertAddendIds;
        public GameObject[] DessertSumObjects;
    }

    [SerializeField] int cakeType;
    [SerializeField] GameObject pullApartResult;
    [SerializeField] int pullApartResultCount;
    [SerializeField] Combinations combinations;

    private void Start()
    {
        if (combinations.DessertAddendIds.Length != combinations.DessertSumObjects.Length)
        {
            Debug.Log("Dessert incorrectly serialized! Bugs may ensue.");
        }
        Grabbable grabbable = GetComponent<Grabbable>();
        grabbable.body = GetComponent<Rigidbody>();
        grabbable.OnJointBreak.AddListener(onPullApart);
    }

    void onPullApart(Autohand.Hand hand, Grabbable grabbable)
    {
        if (pullApartResult == null)
        {
            //SoundManager make a sound
        }
        else
        {
            if (pullApartResultCount == 1)
            {
                Instantiate(pullApartResult, transform.position, Quaternion.identity);
            } else if (pullApartResultCount == 2)
            {
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
            } else if (pullApartResultCount == 3)
            {
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0.1f, 0, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0, 0.1f), Quaternion.identity);
            }
            else if (pullApartResultCount == 4)
            {
                Instantiate(pullApartResult, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0, 0.5f), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0, -0.5f), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        Dessert otherCake = collision.collider.GetComponent<Dessert>();

        if (collision.relativeVelocity.magnitude > BalanceSheet.minCollisionMag
            && otherCake != null && otherCake.GetInstanceID() > GetInstanceID())
        {
            int otherCakeID = otherCake.cakeType;
            int addableIndex = -1;

            for (int i = 0; i < combinations.DessertAddendIds.Length; i++)
            {
                if (otherCakeID == combinations.DessertAddendIds[i])
                {
                    addableIndex = i;
                    break;
                }
            }

            if (addableIndex > -1)
            {
                Instantiate(combinations.DessertSumObjects[addableIndex],
                    Vector3.Lerp(transform.position, collision.transform.position, 0.5f),
                    Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            } else
            {
                //TODO play a bad sound
            }
        }
    }

    public void onPullApartFailure()
    {
        //TODO play a bad sound
    }

    



}
