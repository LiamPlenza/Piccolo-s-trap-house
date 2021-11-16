using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public float radius = 2f;

    public Text text;

    public GameObject player;

    /*public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        text = GameObject.FindWithTag("Press E").GetComponent<Text>();
    }
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        text = GameObject.FindWithTag("Press E").GetComponent<Text>();
    }*/

    public virtual void Interact ()
    {
        Debug.Log("Interacting with " + transform.name);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            text.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
                Interact();
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            text.enabled = false;
        }
    }

    private void Update()
    {

        player = GameObject.FindWithTag("Player");
        text = GameObject.FindWithTag("Press E").GetComponent<Text>();



        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= radius)//&& isFocus == true)S
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
