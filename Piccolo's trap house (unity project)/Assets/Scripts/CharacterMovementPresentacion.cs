using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementPresentacion : MonoBehaviour
{
    public float speed = 4f;

    public int life = 2;

    private float speedIndicator;
    private float timer = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (life == 1) {
            timer += Time.deltaTime; 
            if (timer < 3.0f)
                speed = 10.0f;
            else if (speedIndicator == 1)
                speed = 7.5f;
            else if (speedIndicator == 2)
                speed = 3.5f;
        }
        else if (life == 0)
            Destroy(gameObject);
        else if (speedIndicator == 1)
            speed = 8.0f;
        else if (speedIndicator == 2)
            speed = 4.0f;
        
    }

    public void reduceLife(){
        life -= 1;
    }
}
