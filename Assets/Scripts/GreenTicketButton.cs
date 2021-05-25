using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GreenTicketButton : MonoBehaviour
{
    public GameObject GreenPrefab;

    public TextMeshPro ticketText;
    public int ticketCount = 0;
    
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
            Instantiate(GreenPrefab, new Vector3(10.06333f, 3.659114f, 5.168297f), Quaternion.Euler(0f, 31f, 0f));
            ticketCount++;
            ticketText.text = Convert.ToString(ticketCount);
        }
    }

}
