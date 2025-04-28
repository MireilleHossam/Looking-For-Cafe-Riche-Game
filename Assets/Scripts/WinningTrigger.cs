using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinningTrigger : MonoBehaviour
{
  
    public GameObject winningUICanvas;

    private void Start()
    {
        if (winningUICanvas != null)
        {
            winningUICanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (winningUICanvas != null)
            {
                Debug.Log("Player reached CAFE RICHE");
                winningUICanvas.SetActive(true);
                //Time.timeScale = 0.1f; // Pause the game

                // Enable UI interactions
               // EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

    public void ResumeGame()
    {
        //Time.timeScale = 1f; // Resume game
        winningUICanvas.SetActive(false);
    }
}




