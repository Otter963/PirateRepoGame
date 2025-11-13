using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputActionAsset playerControls;
    private InputAction pauseAction;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject interactUI;
    public bool isPaused;
    public bool resumeGame;

    private void Awake()
    {
        pauseAction = playerControls.FindAction("PauseGame");
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (pauseAction.WasPressedThisFrame())
        {
            if (isPaused)
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
        playerUI.SetActive(false);
        interactUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        resumeGame = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        playerUI.SetActive(true);
        interactUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        resumeGame = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
