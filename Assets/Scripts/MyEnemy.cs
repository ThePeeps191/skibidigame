using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    public float distance;
    public Transform Player;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, Player.position);

        if(distance < 10)
        {
            navMeshAgent.destination = Player.position;
        }
    }
}
