using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppedTreeController : MonoBehaviour
{
    public GameObject logPrefab; // Prefab do log
    public GameObject rootPrefab; // Prefab da root

    public void SpawnLogsAndRoot()
    {
        Instantiate(logPrefab, transform.position + Vector3.up, Quaternion.identity);
        Instantiate(logPrefab, transform.position + Vector3.up, Quaternion.Euler(0, 45, 0)); // Ajuste os valores de rotação conforme necessário
        Instantiate(rootPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // Destrua o objeto da árvore cortada
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class TreeController : MonoBehaviour
//{
//    public GameObject shatteredTree; 
//
//
//    public void BreakTree()
//    {
//        shatteredTree.SetActive(true);
//        gameObject.SetActive(false);
//        //add sounds or particles here
//    }
//}
