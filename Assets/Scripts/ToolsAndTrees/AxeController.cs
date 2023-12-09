//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class AxeController : MonoBehaviour
//{
//    public Collider axeTipCollider; // Arraste o collider da ponta do machado aqui
//    public float breakThreshold = 8f;
//    public float damage = 20f; // Dano causado ao bater com o machado

//    private Rigidbody axeRb;

//    // Adicione uma referência ao ChoppableTree
//    public ChoppableTree choppableTree;

//    // Start is called before the first frame update
//    private void Start()
//    {
//        axeRb = GetComponent<Rigidbody>(); // Obtenha o Rigidbody no objeto atual
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        // Verifique se a colisão é com o collider da ponta do machado
//        if (collision.contacts[0].thisCollider == axeTipCollider && collision.gameObject.CompareTag("Tree"))
//        {
//            // Calcule o fator de ângulo
//            float impactAngleFactor = Vector3.Dot(-axeTipCollider.transform.right, collision.contacts[0].normal);

//            // Verifique se o ângulo não é negativo
//            impactAngleFactor = Mathf.Abs(impactAngleFactor);

//            // Calcule a velocidade
//            Vector3 tipVelocity = axeRb.GetPointVelocity(axeTipCollider.transform.position);

//            // Modifique a força com base no ângulo de impacto
//            float modifiedForce = tipVelocity.magnitude * impactAngleFactor;

//            // Verifique se o impacto é forte o suficiente para quebrar
//            if (modifiedForce > breakThreshold)
//            {
//                // Chame a função TakeDamage na árvore
//                choppableTree.TakeDamage(damage);
//            }
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{

    public Collider axeTipCollider; //drag the axe tip's collider here


    // Start is called before the first frame update
    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check if the collision is with the axe tip's collider
        if (collision.contacts[0].thisCollider == axeTipCollider && collision.gameObject.CompareTag("Tree"))
        {
          
                collision.gameObject.transform.parent.GetComponent<transformController>().Break();
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
