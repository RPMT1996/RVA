using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{

    public Collider axeTipCollider; //drag the axe tip's collider here

    private Rigidbody axeRb;
    private float breakThreshold = 8f;

    // Start is called before the first frame update
    private void Start()
    {
        axeRb = GetComponent<Rigidbody>(); //Ger the Rigidbody on current object
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if the collision is with the axe tip's collider
        if (collision.contacts[0].thisCollider == axeTipCollider && collision.gameObject.CompareTag("Tree"))
        {
            //calculate angle
            float impactAngleFactor = Vector3.Dot(-axeTipCollider.transform.right, collision.contacts[0].normal);

            //check if angle isn't negative
            impactAngleFactor = Mathf.Abs(impactAngleFactor);

            //calculate velocity
            Vector3 tipVelocity = axeRb.GetPointVelocity(axeTipCollider.transform.position);

            //modify force based on the impact angle
            float modifiedForce = tipVelocity.magnitude * impactAngleFactor;

            //check if the impact is strong enough to break
            if( modifiedForce > breakThreshold)
            {
                collision.gameObject.transform.parent.GetComponent<TreeController>().BreakTree();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
