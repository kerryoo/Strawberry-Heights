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
    [SerializeField] int maxPos;
    [SerializeField] int minPos;

    [SerializeField] GameObject[] clouds;
    [SerializeField] Vector3 minXYZ;
    [SerializeField] Vector3 maxXYZ;
    [SerializeField] Vector3 cloudVelcity;

    Dictionary<GameObject, Vector3> existingCars = new Dictionary<GameObject, Vector3>();
    HashSet<GameObject> existingClouds = new HashSet<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
        spawnCar();
        spawnCloud();
    }

    private void Update()
    {
        //cars
        HashSet<GameObject> toDestroyCar = new HashSet<GameObject>();
        foreach(KeyValuePair<GameObject, Vector3> car in existingCars)
        {
            car.Key.transform.Translate(car.Value * Time.deltaTime);
            
            if (car.Key.transform.position.x < minPos || car.Key.transform.position.x > maxPos)
            {
                toDestroyCar.Add(car.Key);
            }
        }
        foreach(GameObject car in toDestroyCar)
        {
            existingCars.Remove(car);
            Destroy(car);
        }
        //cloud
        HashSet<GameObject> toDestroyCloud = new HashSet<GameObject>();
        foreach (GameObject cloud in existingClouds)
        {
            cloud.transform.Translate(cloudVelcity * Time.deltaTime);

            if (cloud.transform.position.x < minXYZ.x || cloud.transform.position.x > maxXYZ.x)
            {
                toDestroyCloud.Add(cloud);
            }
            if (cloud.transform.position.y < minXYZ.y || cloud.transform.position.y > maxXYZ.y)
            {
                toDestroyCloud.Add(cloud);
            }
            if (cloud.transform.position.z < minXYZ.z || cloud.transform.position.z > maxXYZ.z)
            {
                toDestroyCloud.Add(cloud);
            }
        }
        foreach (GameObject cloud in toDestroyCloud)
        {
            existingClouds.Remove(cloud);
            if (toDestroyCloud.Contains(cloud))
            {
                Destroy(cloud);
            }
        }
    }

    private void spawnCar()
    {
        spawnCarHelper(startCarPos1, carVelocity, carRotate);
        spawnCarHelper(startCarPos2, carVelocity, -carRotate);

        Invoke("spawnCar", Random.Range(3, 10));
    }

    private void spawnCarHelper(Vector3 startPost, Vector3 velocity, Vector3 rotation)
    {
        GameObject car = Instantiate(cars[Random.Range(0, cars.Length)], startPost, Quaternion.identity);
        car.transform.Rotate(rotation);
        existingCars.Add(car, velocity);
    }

    private void spawnCloud()
    {
        spawnCloudHelper();
        Invoke("spawnCloud", 2f);
    }

    private void spawnCloudHelper()
    {
        Vector3 cloudPosition = new Vector3(Random.Range(minXYZ.x, maxXYZ.x), Random.Range(minXYZ.y, maxXYZ.y), Random.Range(minXYZ.z, maxXYZ.z));
        GameObject cloud = Instantiate(clouds[Random.Range(0,clouds.Length)], cloudPosition, Quaternion.identity);
        int cloudSize = Random.Range(1,5);
        cloud.transform.localScale += new Vector3(cloudSize, cloudSize, cloudSize);
        existingClouds.Add(cloud);
    }
}
