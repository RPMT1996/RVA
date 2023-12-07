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
        if (collision.contacts[0].thisCollider == hammerTipCollider && collision.gameObject.CompareTag("teste"))
        {
            // Calcule o fator de ângulo
            float impactAngleFactor = Vector3.Dot(-hammerTipCollider.transform.right, collision.contacts[0].normal);

            // Verifique se o ângulo não é negativo
            impactAngleFactor = Mathf.Abs(impactAngleFactor);

            // Calcule a velocidade
            Vector3 tipVelocity = hammerRb.GetPointVelocity(hammerTipCollider.transform.position);

            // Modifique a força com base no ângulo de impacto
            float modifiedForce = tipVelocity.magnitude * impactAngleFactor;

            // Verifique se o impacto é forte o suficiente para quebrar
            if (modifiedForce > breakThreshold) { 
                collision.gameObject.transform.GetComponent<transformController>().BreakHood();
            
        }}
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
