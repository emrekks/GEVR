using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField] private int MoneyAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (collision.gameObject.CompareTag("Money1"))
            {
                MoneyAmount += 1;
            }
            if (collision.gameObject.CompareTag("Money5"))
            {
                MoneyAmount += 5;
            }
            if (collision.gameObject.CompareTag("Money10"))
            {
                MoneyAmount += 10;
            }
            Destroy(collision.gameObject);
        }
    }

}
