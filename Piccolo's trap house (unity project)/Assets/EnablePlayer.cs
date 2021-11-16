using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlayer : MonoBehaviour
{
    public GameObject varGameObject;
     
    void Start()
    {
        varGameObject = GameObject.FindWithTag("Player");
        varGameObject.GetComponent<CharacterMovement>().enabled = true;
    }
    // Start is called before the first frame update

    void Awake() {
        varGameObject = GameObject.FindWithTag("Player");
        varGameObject.GetComponent<CharacterMovement>().enabled = true;
    }

    void Update()
    {
        varGameObject = GameObject.FindWithTag("Player");
        varGameObject.GetComponent<CharacterMovement>().enabled = true;
    }
}
