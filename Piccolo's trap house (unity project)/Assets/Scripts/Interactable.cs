using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    public Text text;

    //public Transform player;

    public GameObject player;

    void Start() {
        player = GameObject.FindWithTag("zombie");
    }

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            text.text = "Press E to interact";

            if (Input.GetKeyDown(KeyCode.E))
                Interact();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            text.text = "";
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= radius)//&& isFocus == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
                Interact();
        }
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
