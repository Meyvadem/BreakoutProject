using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image GameOverScreen;
    public Image WinGameScreen;

    void Update()
    {
        if (ParameterManager.Instance.player.currentLives <= 0)
        {
            GameOver();
        }

        if (BoxController.GetBoxNumber() <= 0)
        {
            WinGame();
        }


    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        WinGameScreen.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        enabled = false;
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
