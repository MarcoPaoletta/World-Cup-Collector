using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    [SerializeField] private Text amountText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Text buyButtonText;

    public void CheckMaxBoostAmount()
    {
        if(amountText.text == "5")
        {
            buyButton.interactable = false;
            buyButtonText.text = "max";
        }
    }
}