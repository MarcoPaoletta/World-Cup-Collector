using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private Text trophiesText;

    private void Update()
    {
        SetTrophiesText();
    }   

    private void SetTrophiesText()
    {
        trophiesText.text = GameManager.cups.ToString();
    }
}