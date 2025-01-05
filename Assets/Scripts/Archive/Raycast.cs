using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] LayerMask MirrorLayerMask;

    public float MaxRayDistance = 200;
    public bool DoesHit;

    // Update is called once per frame
    void Update()
    {
        IfMirror();
    }

    void IfMirror()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, MaxRayDistance, MirrorLayerMask))
        {
            Debug.Log("Hit the mirror");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
            DoesHit = true;
        }
        else
        {
            Debug.Log("Missed the mirror");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
            DoesHit = false;

        }
    }


}
