using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformController : MonoBehaviour
{
    public GameObject shatteredHood;

    public void BreakHood()
    {
        shatteredHood.SetActive(true);
        gameObject.SetActive(false);
        //add sounds or particles here
    }
}
