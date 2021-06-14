using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AI : MonoBehaviour
{

    public Transform _standReferance;
    public Transform ref2;
    //public GameObject referance;
    public bool frontFull = false;
    private NavMeshAgent _agent;
    private float peopleSpeed;
    public bool inLine = false;
    public float radius;

    private GameObject money5;
    private GameObject money10;

    private Vector3 collision;

    public int rndTicket;

    private bool canGo = false;

    public bool moneyGave = true;
    private TextMeshProUGUI panelText;
    


    // Start is called before the first frame update
    void Start()
    {
        peopleSpeed = 2f;
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = peopleSpeed;
        rndTicket = Random.Range(0, 2);
        money5 = GameObject.FindGameObjectWithTag("Money5");
        money10 = GameObject.FindGameObjectWithTag("Money10");
        panelText = GameObject.FindGameObjectWithTag("PeopleTalkText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
        FaceTowards();

        if (!canGo)
        {
            _agent.SetDestination(_standReferance.position); 
        }
        else
        {
            _agent.SetDestination(ref2.position);
        }
        

        if (inLine)
        {
            PeopleInLine();
        }
        
        

        if (Mathf.Abs(Vector3.Distance(_standReferance.position, transform.position)) < 2f)
        {
            inLine = true;
        }
        else
        {
            inLine = false;
        }

        if (frontFull)
        {
            _agent.speed = 0f;
            _agent.Stop();
            _agent.enabled = false;
            //gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            _agent.enabled = true;
            _agent.speed = peopleSpeed;
            _agent.Resume();
            //gameObject.GetComponent<NavMeshAgent>().enabled = true;
        }
        
        
        RaycastHit hit;

        //Vector3 p1 = transform.position;
        float distanceToObstacle = 0;

        // Cast a sphere wrapping character controller 10 meters forward
        // to see if it is about to hit anything.
        if (Physics.SphereCast(transform.position,radius,transform.forward,out hit,1f))
        {
            distanceToObstacle = hit.distance;
            collision = hit.point;

            if (distanceToObstacle < radius && hit.collider.CompareTag("People"))
            {
                frontFull = true;
            }
        }
        else
        {
            frontFull = false;
        }
    }

    
    void FaceTowards()
    {
        Vector3 dir = _standReferance.position - transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1 * Time.deltaTime);
    }

    void PeopleInLine()
    {
        _agent.Stop();

        if (rndTicket == 0 && moneyGave)
        {
            Instantiate(money5, TicketArea.instance.ticketAreaRef.transform.position, Quaternion.identity);
            panelText.text = "He Wants Purple Ticket";
            moneyGave = false;
        }
        else if (rndTicket == 1 && moneyGave)
        {
            Instantiate(money10, TicketArea.instance.ticketAreaRef.transform.position, Quaternion.identity);
            panelText.text = "He Wants Green Ticket";
            moneyGave = false;
        }
        
        if (TicketArea.instance.greenTicket)
        {
            //0 Purple 1 Green
            if (rndTicket == 0)
            {
                Case.instance.MoneyAmount -= 5;
            }
            
            else if (rndTicket == 1)
            {
                canGo = true;
            }
        }
        
        if (TicketArea.instance.purpleTicket)
        {
            if (rndTicket == 0)
            {
                canGo = true;
            }
            
            else if (rndTicket == 1)
            {
                Case.instance.MoneyAmount -= 5;
            }
        }

        //StartCoroutine(Timer());
    }

    // IEnumerator Timer()
    // {
    //     yield return new WaitForSeconds(3f);
    //     
    //     
    // }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision,radius);
    }
}
