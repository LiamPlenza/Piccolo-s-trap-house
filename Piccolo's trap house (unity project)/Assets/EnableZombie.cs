using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableZombie : MonoBehaviour
{
    public GameObject varGameObject;
     
    /*void Start()
    {
        varGameObject = GameObject.FindWithTag("Zombie");
        varGameObject.GetComponent<ZombieMovement>().enabled = true;
    }
    // Start is called before the first frame update

    void Awake() {
        varGameObject = GameObject.FindWithTag("Zombie");
        varGameObject.GetComponent<ZombieMovement>().enabled = true;
    }*/

    void Update()
    {
        varGameObject = GameObject.FindWithTag("Zombie");
        varGameObject.GetComponent<ZombieMovement>().enabled = true;
    }
}
