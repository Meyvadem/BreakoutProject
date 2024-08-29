using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLives = 5;
    public int currentLives;


    void Start()
    {
        ParameterManager.Instance.player = this;

        currentLives = maxLives;
        ParameterManager.Instance.healthUI.UpdateLivesUI(currentLives);

    }

    public void LoseLive()
    {
        currentLives--;
        Debug.Log(currentLives);
        ParameterManager.Instance.healthUI.UpdateLivesUI(currentLives);
    }





}
