using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class LightGunTest : MonoBehaviour
{
    public float range = 10f;                       //How far does the gun shoot for
    public Camera FpsCam;                           // The public camera

    public int LitBraziers;
    public int MaxReflections = 5;                  // Max amount of reflections before termination, prevents infinitly reflecting
    public int NumberofReflections;                 // No of Current Reflections
    public int NoBraziersHit;                       // No of Current Braizers Hit
    public bool IsBrazierHit = false;               // Is the Braizer currently hit
    Ray LastRay; // The Previous Ray

    public List<Vector3> BouncePositions = new List<Vector3>();

    public LightGun _lightGunStart;                 //Shoot from the end of the gun
    public LineRenderer LineRend;                   //Line Renderer Coomponent
    public LayerMask Reflective;                    // Layer Mask for Water/Metal/Mirrors
    public LayerMask BraizerMask;                   // Layer Mask for the braziers

    public GameObject CurrentHitObject;             // Stores the current object which is being hit
    public GameObject PreviousHitObject;            // Stores the last object hit
    public Material DefaultMaterial;                // Default off/blue material
    public Material HighlightedMaterial;            // Once hit turn to yellow
    void Start()
    {
        LineRend = GetComponent<LineRenderer>();                    //Get the Line Renderer component
        _lightGunStart = FindObjectOfType<LightGun>();              // Find the end of the gun
        LineRend.enabled = false;                                   // Turn the Line Renderer off
        LineRend.SetPosition(0, _lightGunStart.transform.position); // Set the first position to the end of the gun
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))           //If press left click down
        {
            ShootLaserGun();
            BounceCount();
        }
    }

    void ShootLaserGun()
    {
        RaycastHit hit;                                     //Stores info about what was hit
        Vector3 start = _lightGunStart.transform.position;  //The starting firing position
        Vector3 direction = transform.forward;              // Shooting forwards

        NumberofReflections = 0;                            // Resets to 0 everytime I shoot
        NoBraziersHit = 0;                                  // Resets the current Brazier count to 0
        IsBrazierHit = false;                               // Resets the Brazier hit to false
        LineRend.enabled = true;                            // Enables the Line Renderer

        BouncePositions.Clear();                            // Clears the list
        BouncePositions.Add(start);                         // Adds start to the first position of the list

        CurrentHitObject = null;                            // Sets the current hit object to null

        for (int i = 0; i < MaxReflections; i++)                                         //loops for the number of max reflections
        {
            Ray MyRay = new Ray(start, direction);                                       //creating a new ray called MYRAY with the initial start point + direction
            LastRay = MyRay;                                                             // Allocates the previous ray values to the variable LastRay

            if (Physics.Raycast(MyRay, out hit, range, Reflective))     //Reflective                 //LayerMask OPTIONAL Only if the ray hits something then activate
            {
                start = hit.point;                                                       // The Start point is now the last know point where the ray hit a surface
                direction = Vector3.Reflect(direction, hit.normal);                      // Reflects the gizmo line of a surface
                BouncePositions.Add(hit.point);                                          // Adds the current point to the list

                NumberofReflections++;                                                   // Increases reflections by 1

                if (Physics.Raycast(MyRay, out hit, range, BraizerMask))                 // If the ray hit a brazier
                {
                    NoBraziersHit++;                                                     // Increase the number of braziers by 1
                    IsBrazierHit = true;                                                 // Sets the brazier hit to true
                    LitBraziers++;                                                       //Debug.Log("Hitting Brazier");

                    Renderer SelectedObjectRenderer = hit.transform.GetComponent<Renderer>();           // Gets the renderer component of the hit object
                    SelectedObjectRenderer.material = HighlightedMaterial;                              // Sets the material to the Highlighted material
                    CurrentHitObject = hit.transform.gameObject;                                        // Sets the current hit object to the transform of what was hit
                    PreviousHitObject = CurrentHitObject;                                               // Sets the previous hit to the current hit object
                }
            }
            else
            {
                BouncePositions.Add(start + direction * 5);     //Visually bounces again after hitting the last available object
                break;                                          // Ends the loop if it doesn't hit anything
            }
        }
    }
    void BounceCount()
    {
        if (BouncePositions.Count > 1)
        {
            LineRend.positionCount = BouncePositions.Count;
            LineRend.SetPositions(BouncePositions.ToArray());
        }
        else
            LineRend.positionCount = 2;
        LineRend.SetPosition(0, _lightGunStart.transform.position + transform.forward);
    }
}
