using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformController : MonoBehaviour
{
    public GameObject shattered;

    public void Break()
    {
        shattered.SetActive(true);
        gameObject.SetActive(false);
        //add sounds or particles here
    }
}
