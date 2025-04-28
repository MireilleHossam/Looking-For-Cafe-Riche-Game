using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    //Upon collision with another GameObject, this GameObject will reverse direction
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            Debug.Log("Collision detected ...");// to show on the console that a collision took place
            //SceneManager.LoadScene("TrainStation_Scene03"); // this reloads the scene OR can move to a new sceens upon collisions
            SceneManager.LoadScene("MetroEntrance_Scene02"); // this reloads the scene OR can move to a new sceens upon collisions

        }
    }

}
