using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TutorialTeo : MonoBehaviour
{
    [SerializeField] private Animator teoAnimator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform playerTransform;

    [SerializeField] float targetPositionTolerance = 1f;
    [SerializeField] float targetRotationTolerance = 0.1f;


    public void rotateToPlayer()
    {
        StartCoroutine(goToRotation(playerTransform.position));
    }

    public void startTalking(Vector3 customerLocation)
    {
        StartCoroutine(takeOrderRoutine(customerLocation));
    }

    IEnumerator goToLocation(Vector3 targetPos)
    {
        bool inPosition = false;

        while (!inPosition)
        {
            navMeshAgent.destination = targetPos;
            teoAnimator.SetFloat("MoveSpeed", 1f);

            if (Vector3.Distance(targetPos, transform.position) <= targetPositionTolerance)
            {
                inPosition = true;
            }
            yield return null;
        }
        teoAnimator.SetFloat("MoveSpeed", 0);
    }

    IEnumerator goToRotation(Vector3 lookLocation)
    {
        bool inRotation = false;
        Vector3 relativePos = lookLocation - transform.position;
        Quaternion targetRot = Quaternion.LookRotation(relativePos);
        float timeCount = 0;

        while (!inRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, timeCount);
            timeCount = timeCount + Time.deltaTime;
            if (Quaternion.Angle(transform.rotation, targetRot) <= targetRotationTolerance)
            {
                inRotation = true;
            }
            yield return null;
        }
    }

    IEnumerator takeOrderRoutine(Vector3 customerLocation)
    {
        yield return goToRotation(customerLocation);
        yield return new WaitForSeconds(3f);
        teoAnimator.SetBool("Yes", true);
        yield return new WaitForSeconds(2f);
        teoAnimator.SetBool("Conversation", true);
    }

}
