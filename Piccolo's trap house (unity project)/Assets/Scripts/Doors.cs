using UnityEngine;

public class Doors : Interactable
{
    public Animator animator;
    public override void Interact()
    {
        base.Interact();

        RotateDoor();
    }

    void RotateDoor()
    {
        animator.Trigger();
    }
}