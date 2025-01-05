using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HidingWeapon : MonoBehaviour
{
    public bool IsHoldingWeapon; 
   
    void Start()
    {
        IsHoldingWeapon = false; //Initially not holding the weapon
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            IsHoldingWeapon = true;
            Debug.Log("Holding Weapon");
        }

        if(Input.GetKeyDown(KeyCode.R))
        { 
            IsHoldingWeapon = false;
            Debug.Log("Not holding weapon");
        }
    }


}
