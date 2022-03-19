using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;

public class CakeSubmissionPad : MonoBehaviour
{
    [SerializeField] BakeryManager bakeryManager;
    [SerializeField] GameObject cashExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        Box collidedBox = collision.transform.GetComponent<Box>();
        if (collidedBox != null && collidedBox.gradeable() && !collidedBox.submitted)
        {
            collidedBox.submitted = true;
            int cash = bakeryManager.gradeCake(collidedBox.connectedDesserts,
                collidedBox.attachedTicket.cakesToCounts,
                collidedBox.attachedTicket.getTimeLeft(),
                collidedBox.attachedTicket.id);

            GameObject explosion = Instantiate(cashExplosion, collidedBox.transform.position, Quaternion.identity);
            var main = explosion.GetComponent<ParticleSystem>().main;
            main.maxParticles = cash;
            collidedBox.transform.GetComponent<Grabbable>().ForceHandsRelease();
            Destroy(collidedBox.gameObject);
        }
    }

}
