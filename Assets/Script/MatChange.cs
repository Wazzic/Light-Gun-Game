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
        //ResetMat();
    }

    void MaterialChange()
    {
        if (!lightGunTest.IsBrazierHit)
        {
            Renderer SelectedObjectRenderer = GetComponent<Renderer>();
            SelectedObjectRenderer.material = DefaultMaterial;
        }
    }
    void ResetMat()
    {
        if (lightGunTest.CurrentHitObject == null)
        {
            //Debug.Log("Turning Blue2");
            Renderer SelectedObjectRenderer = lightGunTest.PreviousHitObject.GetComponent<Renderer>();
            SelectedObjectRenderer.material = DefaultMaterial;
        }
    }
}
