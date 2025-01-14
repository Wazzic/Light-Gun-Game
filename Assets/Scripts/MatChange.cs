using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatChange : MonoBehaviour
{
    LightGunTest lightGunTest;
    public GameObject LightGunObj;
    public Material DefaultMaterial;
    //private bool DidHit2 = false;

    private void Start()
    {
        lightGunTest = LightGunObj.GetComponent<LightGunTest>();
    }

    private void Update()
    {
        MaterialChange();
    }

    void MaterialChange()
    {
        if (!lightGunTest.IsBrazierHit)
        {
            //Debug.Log("Turning Blue");
            //if (!DidHit2)
            {
                //Debug.Log("Did hit 2 = false");
                Renderer SelectedObjectRenderer = GetComponent<Renderer>();
                SelectedObjectRenderer.material = DefaultMaterial;
            }
        }
        //if(lightGunTest.NoBraziersHit>=2)
        //{
            //Debug.Log("Keep braziers yellow");
            //DidHit2 = true;
        //}
    }
}
