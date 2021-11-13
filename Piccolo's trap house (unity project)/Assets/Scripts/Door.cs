using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator myDoor = null;

    public bool isOpen = false;

    public bool isClose = true;

    public override void Interact()
    {
        base.Interact();

        if (isClose == true)
            OpenDoor();
        else if (isOpen)
            CloseDoor();
    }

    public void OpenDoor()
    {
        Debug.Log("Open door");
        myDoor.Play("DoorOpen", 0, 0.0f);
        isClose = false;
        isOpen = true;
    }

    public void CloseDoor()
    {
        Debug.Log("Close door");
        myDoor.Play("DoorClose", 0, 0.0f);
        isClose = true;
        isOpen = false;
    }
}
