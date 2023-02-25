using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BuyButton : MonoBehaviour
{   
    [SerializeField] private int price;

    [Header("SFX")]
    [SerializeField] private AudioClip notEnoughMoneySFX;
    [SerializeField] private AudioClip uiSFX;
    

    [Header("Skins")]
    [SerializeField] private string priceWithK;

    [Header("Upgrades")]
    [SerializeField] private Upgrade upgradeScript;

    [Header("Boosts")]
    [SerializeField] private Text amountText;
    [SerializeField] private Boost boostScript;

    private Button button;
    private Image buttonImage;
    private Text buttonText;
    private Color normalButtonColor;
    private Color selectedButtonColor;
    private Color boughtButtonColor;

    #region Start

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnBuyButtonClicked);
        AssignVariables();
        SetColors();
        LoadData();
        UpdateSkinButtons();

        if(gameObject.name.Contains("Upgrade"))
        {
            upgradeScript.SetUpgradeImage();
            upgradeScript.CheckMaxUpgradeLevel();
        }

        SetAmountText();
    }

    private void AssignVariables()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<Text>();
    }

    private void SetColors()
    {
        ColorUtility.TryParseHtmlString("#3A5771", out normalButtonColor);
        ColorUtility.TryParseHtmlString("#FF9800", out selectedButtonColor);
        ColorUtility.TryParseHtmlString("#E9D439", out boughtButtonColor);
    }

    #endregion

    #region Update

    private void Update()
    {
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        if(buttonImage.color == selectedButtonColor)
        {
            buttonText.text = "picked";
        }

        if(buttonImage.color == normalButtonColor && buttonText.text == "picked")
        {
            buttonText.text = "bought";
        }  

        if(buttonText.text == "bought")
        {
            buttonImage.color = boughtButtonColor;
        }
    }

    private void LoadData()
    {
        if(SaveManager.LoadGameManagerData() != null)
        {
            GameManager.LoadData();
            SaveManager.SaveGameManagerData();
        }

        if(SaveManager.LoadShopManagerData() != null)
        {
            ShopManager.LoadData();
            ShopManager.skinsBought.Add(1);
        }
    }  

    private void UpdateSkinButtons()
    {
        if(gameObject.name.Contains("Skin"))
        {
            foreach(var skin in ShopManager.skinsBought)
            {
                if(gameObject.name.Contains(skin.ToString()))
                {
                    buttonText.text = "bought";
                    buttonImage.color = boughtButtonColor;
                }
            }

            if(gameObject.name.Contains(ShopManager.selectedSkin.ToString()))
            {
                buttonText.text = "picked";
                buttonImage.color = selectedButtonColor;
            }
        }
    } 

    #endregion

    #region OnBuyButtonClicked

    private void OnBuyButtonClicked()
    {
        if(gameObject.name.Contains("Skin"))
        {
            if(itemAlreadyBought())
            {
                ChangeButtonStyle();
                AudioManager.instance.PlaySFX(uiSFX);
            }

            if(ifEnoughMoneyAvailable() && !itemAlreadyBought())
            {
                DecreaseCups();
                SetSkinsBought();
                ChangeButtonStyle();
                AudioManager.instance.PlaySFX(uiSFX);
            }

            if(!ifEnoughMoneyAvailable() && !itemAlreadyBought())
            {
                AudioManager.instance.PlaySFX(notEnoughMoneySFX);
            }

            SetSelectedSkin();
        }

        if(gameObject.name.Contains("Upgrade"))
        {
            if(ifEnoughMoneyAvailable())
            {
                DecreaseCups();
                SetUpgrade();
                upgradeScript.SetUpgradeImage();
                upgradeScript.CheckMaxUpgradeLevel();
                AudioManager.instance.PlaySFX(uiSFX);
            }

            if(!ifEnoughMoneyAvailable())
            {
                AudioManager.instance.PlaySFX(notEnoughMoneySFX);
            }
        }

        if(gameObject.name.Contains("Boost"))
        {
            if(ifEnoughMoneyAvailable())
            {
                DecreaseCups();
                SetBoost();
                SetAmountText();
                boostScript.CheckMaxBoostAmount();
                AudioManager.instance.PlaySFX(uiSFX);
            }

            if(!ifEnoughMoneyAvailable())
            {
                AudioManager.instance.PlaySFX(notEnoughMoneySFX);
            }
        }

        SaveManager.SaveShopManagerData();
        SaveManager.SaveGameManagerData();
    }

    private bool ifEnoughMoneyAvailable()
    {
        return GameManager.cups >= price;
    }

    private void DecreaseCups()
    {
        GameManager.cups -= price;
    }

    #endregion

    #region Skins

    private bool itemAlreadyBought()
    {
        if(buttonText.text == "picked" || buttonText.text == "bought")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetSkinsBought()
    {
        int itemIndex;
        int.TryParse(gameObject.name.Replace("Skin", "").Replace("BuyButton", ""), out itemIndex);
        ShopManager.skinsBought.Add(itemIndex);
    }

    private void ChangeButtonStyle()
    {
        ResetButtonColors();
        SetSelectedButtonColor();
    }

    private void ResetButtonColors()
    {
        foreach(var button in GameObject.FindGameObjectsWithTag("BuyButton"))
        {
            button.GetComponent<Image>().color = normalButtonColor;
            buttonText.text = priceWithK;
        }
    }

    private void SetSelectedButtonColor()
    {
        buttonImage.color = selectedButtonColor;
        buttonText.text = "picked";
    }

    private void SetSelectedSkin()
    {
        int selectedSkin;

        if(buttonText.text == "picked")
        {
            int.TryParse(gameObject.name.Replace("Skin", "").Replace("BuyButton", ""), out selectedSkin);
            ShopManager.selectedSkin = selectedSkin;
        }
    }

    #endregion

    #region Upgrades

    private void SetUpgrade()
    {
        ShopManager.upgradeLevels[transform.parent.GetChild(0).name] += 1;
    }

    #endregion

    #region Boosts

    private void SetBoost()
    {
        ShopManager.boostsAmount[transform.parent.GetChild(0).name] += 1;
    }

    private void SetAmountText()
    {
        if(gameObject.name.Contains("Boost"))
        {
            amountText.text = ShopManager.boostsAmount[transform.parent.GetChild(0).name].ToString();
        }
    }

    #endregion
}