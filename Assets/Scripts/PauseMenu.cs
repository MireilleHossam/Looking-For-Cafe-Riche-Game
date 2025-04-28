using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;  // Assign Pause Canvas in Inspector
    public Button continueButton;   // Assign Continue Button in Inspector
    private bool isPaused = false;
    private bool canPause = true;   // Prevents input glitch immediately after resume

    void Start()
    {
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(ResumeGame);
        }

        pauseCanvas.SetActive(false); // Hide pause menu initially
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            Debug.Log("Escape Pressed - isPaused: " + isPaused);

            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pausing Game - Enabling Pause Canvas");

        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        canPause = false;

        // Wait before allowing Escape again
        StartCoroutine(ReenablePauseInput());
    }

    public void ResumeGame()
    {
        Debug.Log("Resuming Game - Disabling Pause Canvas");

        StartCoroutine(ResumeAfterDelay());
    }

    private System.Collections.IEnumerator ResumeAfterDelay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.05f); // Tiny delay to avoid input conflict

        pauseCanvas.SetActive(false);
        isPaused = false;

        // Wait before Escape can be used again to prevent double toggling
        yield return new WaitForSecondsRealtime(0.2f);
        canPause = true;
    }

    private System.Collections.IEnumerator ReenablePauseInput()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        canPause = true;
    }
}
