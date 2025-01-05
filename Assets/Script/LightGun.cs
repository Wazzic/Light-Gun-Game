using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LightGun : MonoBehaviour
{
    public float range = 50f;                      //How far does the gun shoot for
    public Camera FpsCam;                           // The public camera

    public int MaxReflections = 5;                  // Max amount of reflections before termination, prevents infinitly reflecting
    public int NumberofReflections;
    Ray LastRay; // The Previous Ray

    public List<Vector3> BouncePositions = new List<Vector3>();

    public LightGun _lightGunStart;
    public LineRenderer LineRend;
    public LayerMask LayersToHit;

    void Start()
    {
        LineRend = GetComponent<LineRenderer>();
        _lightGunStart = FindObjectOfType<LightGun>();
        LineRend.enabled = false;
        LineRend.SetPosition(1, _lightGunStart.transform.position);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootLaserGun();
        }
    }

    void ShootLaserGun()
    {
        {
            RaycastHit hit;                                                                 //Stores info about what was hit
            Vector3 start = transform.position;                                             //The starting firing position
            Vector3 direction = transform.forward;                                          // Shooting forwards

            NumberofReflections = 0;                                                        // Resets to 0 everytime I shoot
            LineRend.enabled = true;                                                        // Enables the Line Renderer
            BouncePositions.Clear();
            BouncePositions.Add(start);


            for (int i = 0; i < MaxReflections; i++)                                         //loops for the number of max reflections
            {
               Ray MyRay = new Ray(start, direction);                                       //creating a new ray called MYRAY with the initial start point + direction
                LastRay = MyRay;                                                             // Allocates the previous ray values to the variable LastRay

                if (Physics.Raycast(MyRay, out hit, range, MaxReflections))       //MaxReflections               // Only if the ray hits something then activate
                {
                    //Debug.DrawLine(start, hit.point, Color.black, 100f);                   // draws a line, forward from the initial point forwards
                    start = hit.point;                                                       // The Start point is now the last know point where the ray hit a surface
                    direction = Vector3.Reflect(direction, hit.normal);                      // Reflects the gizmo line of a surface
                    BouncePositions.Add(hit.point);

                    NumberofReflections++;                                                   // The number of times it actually hit something                                           
                    Debug.Log("The number of things in ray reflection is: " + BouncePositions.Count);
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50, Color.red);
                    //break; // If it doesn't hit anything then stop the loop
                }
            }
            if (BouncePositions.Count > 1)
            {
                LineRend.positionCount = BouncePositions.Count;
                LineRend.SetPositions(BouncePositions.ToArray());
            }

            else
            //LineRend.SetPositions(null);
            LineRend.positionCount += 1;
            LineRend.SetPosition(LineRend.positionCount - 1, start + direction * 50);
        }
    }
}
