using UnityEngine;

public class ParameterManager : MonoBehaviour
{

    public static ParameterManager Instance { get; private set; }



    public PlayerHealthUI healthUI;
    public BoxNumberUI boxNumberUI;
    public Player player;
    public PowerUpTimerManagerUI TimerUI;



    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }

    }

}
