using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClockUI : MonoBehaviour
{

    public TextMeshPro clockText;
    public int time = 9;
    public int time2 = 0;
    private float timer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (time > 23)
        {
            time = 0;
        }

        if (timer >= 0.25f)
        {
            timer = 0f;

            if (time2 < 59)
            {
                time2++;
            }
            else
            {
                time2 = 0;
                time++;
            }
        }

        if (time2 < 10)
        {
            if (time < 10)
            {
                clockText.text = "0" + time + ":" + "0" + time2;
            }
            else
            {
                clockText.text = time + ":" + "0" + time2;
            }
        }
        else
        {
            if (time < 10)
            {
                clockText.text = "0" + time + ":" + time2;
            }
            else
            {
                clockText.text = time + ":" + time2;
            }
        }
        
    }
}
