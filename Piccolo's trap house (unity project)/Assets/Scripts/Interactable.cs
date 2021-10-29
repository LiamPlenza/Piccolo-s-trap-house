using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    bool isFocus = false;

    public Transform player;

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= radius && isFocus == true)
            if(Input.GetKeyDown(KeyCode.E))
                Interact();
    }

    void OnMouseOver(){
        isFocus = true;
    }

    void OnMouseExit() { 
        isFocus = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
