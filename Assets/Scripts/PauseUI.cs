using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            // Oyun duraklatýldýysa devam ettir
            Time.timeScale = 1f; // Normal oyun hýzýna dön
            isPaused = false;
        }
        else
        {
            // Oyun devam ediyorsa duraklat
            Time.timeScale = 0f; // Oyun zamaný durdur
            isPaused = true;
        }
    }
}
