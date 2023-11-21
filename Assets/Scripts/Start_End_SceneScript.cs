using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamefeatureScript : MonoBehaviour
{   

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Cerrando Juego");
    }
}
