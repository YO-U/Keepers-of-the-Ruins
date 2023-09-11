using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Button restartButton;
    public Button resumeButton;

    private bool isGamePaused = false;

    private void Start()
    {
        pauseCanvas.SetActive(false); // Скрыть панель паузы при запуске игры

        // Назначить методы обработки событий для кнопок
        restartButton.onClick.AddListener(RestartLevel);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void Update()
    {
        // Проверка нажатия клавиши Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0f; // Приостановить игру
        isGamePaused = true;
        pauseCanvas.SetActive(true); // Отобразить панель паузы
    }

    private void ResumeGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1f; // Возобновить игру
        isGamePaused = false;
        pauseCanvas.SetActive(false); // Скрыть панель паузы
    }

    private void RestartLevel()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
       SceneManager.LoadScene(1);
    }
}

