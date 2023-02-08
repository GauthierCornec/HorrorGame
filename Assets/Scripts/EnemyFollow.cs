using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public static EnemyFollow instance;

    public Transform mytarget;
    public NavMeshAgent myAgent;

    private bool isFollowing = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    public void SetAgent()
    {
        myAgent.SetDestination(mytarget.position);
        isFollowing = true;
    }

    void Update()
    {
        if (!isFollowing) return;
        myAgent.SetDestination(mytarget.position);
    }
}
