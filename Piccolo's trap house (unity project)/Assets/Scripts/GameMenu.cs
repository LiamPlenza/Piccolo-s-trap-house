using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// este scrip sirve para salir del juego una vez que estas en la escena game
// agregar desactivar el optionMenu y activar el mainMenu

public class GameMenu : MonoBehaviour
{
    public void GoMenu ()
    {
        SceneManager.LoadScene(0); 
    }
}
