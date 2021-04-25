using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{

    public Transform _standReferance;
    //public GameObject referance;
    private NavMeshAgent _agent;
    private float peopleSpeed;
    public bool frontFull = false;


    // Start is called before the first frame update
    void Start()
    {
        //peopleSpeed = Random.Range(1f, 2.5f);
        peopleSpeed = 2f;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = peopleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        FaceTowards();
        
        _agent.SetDestination(_standReferance.position);

        if (frontFull)
        {
            _agent.speed = 0f;
        }
        else
        {
            _agent.speed = peopleSpeed;
        }


        // if (!PeopleTrigger.instance.spotFull)
        // {
        //     _agent.speed = 1f;
        //     _agent.SetDestination(_standReferance.position);
        // }
        // else
        // {
        //     _agent.speed = 0f;
        // }
    }

    
    void FaceTowards()
    {
        Vector3 dir = _standReferance.position - transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1 * Time.deltaTime);
    }
    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("People"))
        {
            frontFull = true;
        }
        else
        {
            frontFull = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("People"))
        {
            frontFull = true;
        }
        else
        {
            frontFull = false;
        }
    }
}
