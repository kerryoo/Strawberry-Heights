using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviManager : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] Vector3 startCarPos1;
    [SerializeField] Vector3 startCarPos2;
    [SerializeField] Vector3 carRotate;
    [SerializeField] Vector3 carVelocity;
    [SerializeField] float carLifeSpan;

    [SerializeField] GameObject[] clouds;
    [SerializeField] int numberCloud;
    [SerializeField] int cloudSpawnFreq;
    [SerializeField] Vector3 minXYZ;
    [SerializeField] Vector3 maxXYZ;
    [SerializeField] Vector3 cloudVelcity;
    [SerializeField] float cloudLifeSpan;

    private void Start()
    {
        StartCoroutine(spawnCar(startCarPos1, carRotate));
        StartCoroutine(spawnCar(startCarPos2, -carRotate));
        for(int i = 0; i < numberCloud; i++)
        {
            spawnCloudHelper(minXYZ, maxXYZ);
        }
        StartCoroutine(spawnCloud());
    }

    IEnumerator spawnCar(Vector3 startPost, Vector3 rotation)
    {
        while (true)
        {
            GameObject car = Instantiate(cars[Random.Range(0, cars.Length)], startPost, Quaternion.identity);
            car.transform.Rotate(rotation);
            Motion carMotion = car.AddComponent<Motion>();
            carMotion.setParams(carVelocity, carLifeSpan);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

    IEnumerator spawnCloud()
    {
        while (true)
        {
            spawnCloudHelper(minXYZ, new Vector3(minXYZ.x, maxXYZ.y, maxXYZ.z));
            yield return new WaitForSeconds(cloudSpawnFreq);
        }
    }

    public void spawnCloudHelper(Vector3 minXYZ, Vector3 maxXYZ)
    {
        Vector3 cloudPosition = new Vector3(Random.Range(minXYZ.x, maxXYZ.x), Random.Range(minXYZ.y, maxXYZ.y), Random.Range(minXYZ.z, maxXYZ.z));
        GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)], cloudPosition, Quaternion.identity);
        int cloudSize = Random.Range(1, 5);
        cloud.transform.localScale += new Vector3(cloudSize, cloudSize, cloudSize);
        Motion cloudMotion = cloud.AddComponent<Motion>();
        cloudMotion.setParams(cloudVelcity, cloudLifeSpan);
    }
}
