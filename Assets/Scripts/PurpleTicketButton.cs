using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PurpleTicketButton : MonoBehaviour
{
    public GameObject PurplePrefab;
    
    public TextMeshPro ticketText;
    public GreenTicketButton greenTicketButton;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hand")
        {
            Instantiate(PurplePrefab, new Vector3(9.744582f, 3.659114f, 4.671125f), Quaternion.Euler(0f,31f,0f));
            greenTicketButton.ticketCount++;
            ticketText.text = Convert.ToString(greenTicketButton.ticketCount);
        }
    }
}
