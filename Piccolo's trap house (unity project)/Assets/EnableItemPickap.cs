using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItemPickap : MonoBehaviour
{
    public GameObject varGameObject;
    /*
    void Start()
    {
        varGameObject = GameObject.FindWithTag("Item");
        varGameObject.GetComponent<ItemPickup>().enabled = true;
    }
    // Start is called before the first frame update

    void Awake() {
        varGameObject = GameObject.FindWithTag("Item");
        varGameObject.GetComponent<ItemPickup>().enabled = true;
    }
    */
    void Update()
    {
        varGameObject = GameObject.FindWithTag("Item");
        varGameObject.GetComponent<ItemPickup>().enabled = true;
    }
}
