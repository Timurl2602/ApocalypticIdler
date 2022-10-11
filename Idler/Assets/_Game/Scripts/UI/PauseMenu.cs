using IdleGame;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject blur;
    

    private bool _isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UiManager.Instance.IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        blur.SetActive(true);
        Time.timeScale = 0f;
        UiManager.Instance.IsPaused = true;
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        blur.SetActive(false);
        Time.timeScale = 1f;
        UiManager.Instance.IsPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        UiManager.Instance.IsPaused = false;
    }
}
