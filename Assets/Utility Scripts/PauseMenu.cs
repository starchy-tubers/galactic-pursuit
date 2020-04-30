using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public static bool muted;
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
                if (raycastHit.collider.CompareTag("Settings"))
                {
                    if (gameIsPaused)
                        Resume();
                    else
                        Pause();
                }
        }
    }
    private void OnMouseDown()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public void Mute()
    {
        if (muted == false)
        {
            AudioListener.pause = true;
            muted = true;
        }
        else
        {
            AudioListener.pause = false;
            muted = false;
        }
    }
}