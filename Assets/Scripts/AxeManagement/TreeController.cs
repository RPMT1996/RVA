using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject shatteredTree; 


    public void BreakTree()
    {
        shatteredTree.SetActive(true);
        gameObject.SetActive(false);
        //add sounds or particles here
    }
}
