using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Collider hammerTipCollider; 

    private Rigidbody hammerRb;
    private float breakThreshold = 8f;


    private void Start()
    {
        hammerRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if the collision is with the axe tip's collider
        if (collision.contacts[0].thisCollider == hammerTipCollider && collision.gameObject.CompareTag("tronco"))
        {
                collision.gameObject.transform.GetComponent<transformController>().Break();
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
