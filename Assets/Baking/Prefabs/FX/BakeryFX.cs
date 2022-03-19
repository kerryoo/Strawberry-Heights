using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeryFX : MonoBehaviour
{
    [SerializeField] float timeUntilDestruction;

    void Start()
    {
        StartCoroutine(destroySelf());
    }

    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(timeUntilDestruction);
        Destroy(gameObject);
    }

}
