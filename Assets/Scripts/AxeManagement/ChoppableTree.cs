using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ChoppableTree : MonoBehaviour
{
    public bool playerInRange;
    public bool canBeChopped;

    public float treeMaxHealth = 100f; // Vida inicial da árvore
    public float treeHealth;

    private void Start()
    {
        treeHealth = treeMaxHealth; // Adicionado ponto e vírgula aqui
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void TakeDamage(float damage)
    {
        if (canBeChopped)
        {
            treeHealth -= damage;

            if (treeHealth <= 0)
            {
                ChopTree();
            }
        }
    }

    private void ChopTree()
    {
        // Ajustado para chamar a função do próprio script
        GetComponent<ChoppedTreeController>().SpawnLogsAndRoot();
    }
}
