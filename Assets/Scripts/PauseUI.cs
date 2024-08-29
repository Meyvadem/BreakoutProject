using UnityEngine;

public class PauseUI : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            // Oyun duraklat�ld�ysa devam ettir
            Time.timeScale = 1f; // Normal oyun h�z�na d�n
            isPaused = false;
        }
        else
        {
            // Oyun devam ediyorsa duraklat
            Time.timeScale = 0f; // Oyun zaman� durdur
            isPaused = true;
        }
    }
}
