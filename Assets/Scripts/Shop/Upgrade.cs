using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private List<Sprite> upgradesSprites;

    [Header("Components")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Text buyButtonText;
    [SerializeField] private Image image;

    public void SetUpgradeImage()
    {
        foreach(var key in ShopManager.upgradeLevels.Keys)
        {
            if(transform.parent.name == key)
            {
                image.sprite = upgradesSprites[ShopManager.upgradeLevels[key] - 1];
            }
        }
    }

    public void CheckMaxUpgradeLevel()
    {
        if(image.sprite == upgradesSprites[4])
        {
            buyButton.interactable = false;
            buyButtonText.text = "full";
        }
    }
}