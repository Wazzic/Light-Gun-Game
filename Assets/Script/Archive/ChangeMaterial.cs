using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

   [SerializeField] private Material MyMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
            MyMaterial.color = Color.yellow;
    }
}
