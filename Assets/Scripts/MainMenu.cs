using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // dont forget to add this

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //  this reads the scene in file > buildsettings > add scene 
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
