using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] lifeIcons;

    // TODO: Rengi normal color ile ayarlama  
    public Color activeCircle;
    public Color pasiveCircle;


    private void Start()
    {
        ParameterManager.Instance.healthUI = this;
    }

    public void UpdateLivesUI(int lives)
    {

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            if (i < lives)
            {
                lifeIcons[i].color = activeCircle;
            }
            else
            {
                lifeIcons[i].color = pasiveCircle;
            }

        }
    }



}
