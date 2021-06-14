using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketArea : MonoBehaviour
{
    #region Singleton

    public static TicketArea instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion
    


    public bool greenTicket;
    public bool purpleTicket;

    public GameObject ticketAreaRef;
    
    // Start is called before the first frame update
    void Start()
    {
        //ticketAreaRef = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenTicket"))
        {
            greenTicket = true;
            purpleTicket = false;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("PurpleTicket"))
        {
            purpleTicket = true;
            greenTicket = false;
            Destroy(other.gameObject);
        }
    }
}
