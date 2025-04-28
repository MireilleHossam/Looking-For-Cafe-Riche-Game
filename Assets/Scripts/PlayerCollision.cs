using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public AudioClip deathSound;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Collision with Car confirmed!");

            if (audioSource != null && deathSound != null)
            {
                Debug.Log("Playing death sound...");
                audioSource.PlayOneShot(deathSound);
                StartCoroutine(RestartLevelAfterDelay(deathSound.length));
            }
            else
            {
                Debug.LogError("AudioSource or DeathSound missing! Restarting immediately.");
                RestartLevel();
            }
        }
    }

    void Update()
{
    if (Input.GetKeyDown(KeyCode.R))
    {
        Debug.Log("Manual scene reload triggered!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

    IEnumerator RestartLevelAfterDelay(float delay)
    {
        Debug.Log("RestartLevelAfterDelay coroutine started.");
        yield return new WaitForSeconds(delay);
        Debug.Log("Delay finished, now reloading...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void RestartLevel()
    {
        Debug.Log("Forcing scene reload...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
