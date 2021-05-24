using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleTicketButton : MonoBehaviour
{
    public GameObject PurplePrefab;
    public GameObject PurpleButton;
    private Vector3 PrefabRef;
    // Start is called before the first frame update
    void Start()
    {
        PrefabRef = new Vector3(PurpleButton.gameObject.transform.position.x, PurpleButton.gameObject.transform.position.y, PurpleButton.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            Instantiate(PurplePrefab, PrefabRef, Quaternion.identity);
        }
    }
}
