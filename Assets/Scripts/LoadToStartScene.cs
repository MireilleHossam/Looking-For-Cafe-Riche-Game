using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToStartScene : MonoBehaviour
{
    // Function to be called when the button is clicked
    public void LoadScene()
    {
        Debug.Log("Button clicked! Loading Scene: MetroEntrance_Scene02");
        SceneManager.LoadScene("MetroEntrance_Scene02"); // Loads the specified scene
    }

    public void LoadTrainStation()
    {
        Debug.Log("Button clicked! Loading Scene: TrainStation_Scene03");
        SceneManager.LoadScene("TrainStation_Scene03"); // Loads the specified scene
    }

    public void LoadDowntown()
    {
        Debug.Log("Button clicked! Loading Scene: DownTown_Scene04");
        SceneManager.LoadScene("DownTown_Scene04"); // Loads the specified scene
    }
    // Function to be called when the Quit button is clicked
    public void QuitToMainMenu()
    {
        Debug.Log("Quit button clicked! Returning to Main Menu...");
        SceneManager.LoadScene("MainMenu_Scene01"); // Replace "MainMenu" with your main menu scene name
    }
}

