using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatChange : MonoBehaviour
{
    LightGunTest lightGunTest;
    public GameObject LightGunObj;
    public Material DefaultMaterial;

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
            Renderer SelectedObjectRenderer = GetComponent<Renderer>();
            SelectedObjectRenderer.material = DefaultMaterial;
        }
    }
}
