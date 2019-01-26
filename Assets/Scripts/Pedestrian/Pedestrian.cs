using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pedestrian : MonoBehaviour
{
    [SerializeField]
    private GameObject pedestrianTarget;
    private NavMeshAgent nma;

    void Start()
    {
        SetUp();
        SetTarget();
    }

    void SetTarget()
    {
        nma.SetDestination(pedestrianTarget.transform.position);
    }

    void SetUp()
    {
        nma = GetComponent<NavMeshAgent>();
    }
}
