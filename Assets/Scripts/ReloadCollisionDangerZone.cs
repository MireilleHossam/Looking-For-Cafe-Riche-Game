using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ReloadCollisionDangerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            Debug.Log("Trigger detected with Player... Reloading scene");
            SceneManager.LoadScene("TrainStation_Scene03"); // Reloads the current scene
        }
    }
}
