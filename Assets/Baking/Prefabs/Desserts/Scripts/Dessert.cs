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

    private Timer timer;
    private List<float> timesToDiminishFreshness;

    public int freshness { get; private set;}
    public int quality { get; private set; }

    private void Start()
    {
        if (combinations.DessertAddendIds.Length != combinations.DessertSumObjects.Length)
        {
            Debug.Log("Dessert incorrectly serialized! Bugs may ensue.");
        }
        Grabbable grabbable = GetComponent<Grabbable>();
        grabbable.body = GetComponent<Rigidbody>();
        grabbable.OnJointBreak.AddListener(onPullApart);

        freshness = 5;
        quality = 5;
        timesToDiminishFreshness = new List<float>();
        timer = gameObject.AddComponent<Timer>();
        timer.setTimer(BalanceSheet.cakeFreshnessTime);


        for (int i = 0; i < BalanceSheet.freshnessDiminishTimeMultipliers.Length; i++)
        {
            timesToDiminishFreshness.Add(Time.time + BalanceSheet.freshnessDiminishTimeMultipliers[i] * BalanceSheet.cakeFreshnessTime);
        }
    }

    private void Update()
    {
        if (timesToDiminishFreshness.Count > 0 && Time.time > timesToDiminishFreshness[0])
        {
            Debug.Log("Time is " + Time.time);

            freshness--;
            Debug.Log("Quality is " + freshness);
            timesToDiminishFreshness.RemoveAt(0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(freshness);
        }
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
                Instantiate(pullApartResult, transform.position + new Vector3(-0.25f, 0, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0.25f, 0, 0), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0, 0.25f), Quaternion.identity);
                Instantiate(pullApartResult, transform.position + new Vector3(0, 0, -0.25f), Quaternion.identity);
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

    public int getCakeShape()
    {
        return cakeType / 100;
    }

    public int getCakeFlavor()
    {
        return cakeType % 100;
    }

    public int getCakeType()
    {
        return cakeType;
    }

}
