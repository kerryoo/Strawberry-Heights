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

    [SerializeField] GameObject[] pullApartFXs;
    [SerializeField] GameObject[] combineFXs;
    [SerializeField] GameObject expirationExplosion;
    [SerializeField] GameObject stinkiness;
    AudioSource incorrectSound;

    private Timer timer;
    private List<float> timesToDiminishFreshness;

    public int freshness { get; private set;}

    private void Start()
    {
        if (combinations.DessertAddendIds.Length != combinations.DessertSumObjects.Length)
        {
            Debug.Log("Dessert incorrectly serialized! Bugs may ensue.");
        }
        incorrectSound = GetComponent<AudioSource>();
        Grabbable grabbable = GetComponent<Grabbable>();
        grabbable.body = GetComponent<Rigidbody>();
        grabbable.OnJointBreak.AddListener(onPullApart);

        freshness = 5;
        timesToDiminishFreshness = new List<float>();
        timer = gameObject.GetComponent<Timer>();
        timer.setTimer(BalanceSheet.cakeFreshnessTime);
        timer.timeUpEvent.AddListener(expire);


        for (int i = 0; i < BalanceSheet.freshnessDiminishTimeMultipliers.Length; i++)
        {
            timesToDiminishFreshness.Add(Time.time + BalanceSheet.freshnessDiminishTimeMultipliers[i] * BalanceSheet.cakeFreshnessTime);
        }
    }

    private void Update()
    {
        if (timesToDiminishFreshness.Count > 0 && Time.time > timesToDiminishFreshness[0])
        {
            freshness--;
            if (freshness == 2)
            {
                GameObject obj = Instantiate(stinkiness, transform);
                obj.transform.localPosition = Vector3.zero;
            }
            timesToDiminishFreshness.RemoveAt(0);
        }

    }

    void onPullApart(Autohand.Hand hand, Grabbable grabbable)
    {
        if (pullApartResult == null)
        {
            incorrectSound.Play();
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

            Instantiate(pullApartFXs[UnityEngine.Random.Range(0, pullApartFXs.Length)], transform.position, Quaternion.identity);

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
                Instantiate(combineFXs[UnityEngine.Random.Range(0, combineFXs.Length)],
                    Vector3.Lerp(transform.position, collision.transform.position, 0.5f),
                    Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            } else
            {
                incorrectSound.Play();
            }
        }
    }

    public void expire()
    {
        Instantiate(expirationExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
