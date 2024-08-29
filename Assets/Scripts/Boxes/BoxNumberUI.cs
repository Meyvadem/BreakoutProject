using UnityEngine;
using UnityEngine.UI;

public class BoxNumberUI : MonoBehaviour
{
    public Text boxNumber;

    private void Start()
    {
        ParameterManager.Instance.boxNumberUI = this;
    }

    public void UpdateNumberOfBoxUI(int numb)
    {
        boxNumber.text = numb.ToString("00");

    }
}
