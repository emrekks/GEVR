using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRandomPeople : MonoBehaviour
{


    private NavMeshAgent _agent;
    public Transform referance;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(referance.transform.position);
    }
}
