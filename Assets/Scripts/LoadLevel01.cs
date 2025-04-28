using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel01 : MonoBehaviour
{
    [SerializeField] private Animator transitionAnim; // Reference to the transition animator
    [SerializeField] private float transitionTime = 1f; // Time for the transition effect

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the colliding object has the "Player" tag
        {
            Debug.Log("Collision with Player detected...");
            StartCoroutine(LoadNextScene()); // Start transition coroutine
        }
    }

    IEnumerator LoadNextScene()
    {
        transitionAnim.SetTrigger("End"); // Play exit animation
        yield return new WaitForSeconds(transitionTime); // Wait for animation to complete
        SceneManager.LoadScene("TrainStation_Scene03"); // Load the new scene
        transitionAnim.SetTrigger("Start"); // Play entry animation (if needed)
    }
}


