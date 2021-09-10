using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // le digo que cargue la scena siguiente tomando el indice de la scena actual + 1
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!"); // mensaje para comprobar que anda
        Application.Quit();
    }
}
