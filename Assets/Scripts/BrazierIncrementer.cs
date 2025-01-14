using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazierIncrementer : MonoBehaviour
{
    private bool HasHit = false;
    LightGunTest lightguntesting;
    public GameObject LightGunObj;

    private void Start()
    {
        lightguntesting = LightGunObj.GetComponent<LightGunTest>();
    }
    void HitByRay()
    {
        if (!HasHit)
        {
            //Debug.Log("You've hit a Brazier");
            HasHit = true;
            lightguntesting.LitBraziers++;
        }
    }
}
