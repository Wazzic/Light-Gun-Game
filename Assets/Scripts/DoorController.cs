using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public float openRot, closeRot, speed;
    public bool opening;

    LightGunTest lightGunTest;
    public GameObject Place;
    private bool PassedDoor = false;

    private void Start()
    {
        lightGunTest = Place.GetComponent<LightGunTest>();
    }

    void Update()
    {
        SetOpening();
        OpenCloseDoor();
    }

    public void OpenCloseDoor()
    {
        Vector3 currentRot = door.transform.localEulerAngles;
        if (opening)
        {
            if (currentRot.y < openRot)
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, openRot, currentRot.z), speed * Time.deltaTime);
            }
        }
        else
        {
            if (currentRot.y > closeRot)
            {
                door.transform.localEulerAngles = Vector3.Lerp(currentRot, new Vector3(currentRot.x, closeRot, currentRot.z), speed * Time.deltaTime);
            }
        }
    }
    public void SetOpening()
    {
        if (lightGunTest.NoBraziersHit >= 2 || PassedDoor)
        {
            opening = true;
        }
        else
        {
            opening= false;
        }
    }

    public void ToggleDoor()
    {
        opening = !opening;
    }

    private void OnTriggerEnter(Collider other)
    {
        PassedDoor = true;
    }
}