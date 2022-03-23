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

    Dictionary<GameObject, Vector3> existingCars = new Dictionary<GameObject, Vector3>();
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("spawn", 1f,1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            spawnCar(startCarPos1, carVelocity, carRotate);
            spawnCar(startCarPos2, carVelocity, -carRotate);
        }
        foreach(KeyValuePair<GameObject, Vector3> car in existingCars)
        {
            car.Key.transform.Translate(car.Value * Time.deltaTime);
            if (car.Key.transform.position.x < -40 || car.Key.transform.position.x > 50)
            {
                existingCars.Remove(car.Key);
                Destroy(car.Key);
            }
        }
    }

    private void spawn()
    {
        spawnCar(startCarPos1, carVelocity, carRotate);
        spawnCar(startCarPos2, carVelocity, -carRotate);
    }

    private void spawnCar(Vector3 startPost, Vector3 velocity, Vector3 rotation)
    {
        System.Random rnd = new System.Random();
        GameObject car = Instantiate(cars[rnd.Next(0, cars.Length)], startPost, Quaternion.identity);
        car.transform.Rotate(rotation);
        existingCars.Add(car, velocity);
    }
}
