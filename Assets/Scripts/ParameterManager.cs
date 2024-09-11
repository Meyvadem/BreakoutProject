using UnityEngine;

public class ParameterManager : MonoBehaviour
{

    public static ParameterManager Instance { get; private set; }

    public PlayerHealthUI healthUI;
    public BoxNumberUI boxNumberUI;
    public BoxController boxController;
    public Player player;


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
