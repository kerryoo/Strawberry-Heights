using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    Vector3 speed = new Vector3(0,0,0);
    float lifeSpan = 0;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }

    public void setParams(Vector3 speed, float lifeSpan)
    {
        this.speed = speed;
        this.lifeSpan = lifeSpan;
    }
}
