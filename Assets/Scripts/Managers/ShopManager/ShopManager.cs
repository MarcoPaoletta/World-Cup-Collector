using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ShopManager : MonoBehaviour
{
    public static List<int> skinsBought = new List<int>();
    public static Dictionary<string, int> upgradeLevels = new Dictionary<string, int>()
    {
        {"Velocity", 1},
        {"ClockDuration", 1},
        {"Resistance", 1}
    };
    public static Dictionary<string, int> boostsAmount = new Dictionary<string, int>()
    {
        {"DoubleTrophies", 0},
        {"Shield", 0},
        {"NoObstacles", 0},
    };
    public static int selectedSkin = 1;

    public static ShopManager instance;

    private void Awake()
    {
        if(ShopManager.instance == null)
        {
            ShopManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void LoadData()
    {
        ShopManagerData shopManagerData = SaveManager.LoadShopManagerData();
        skinsBought = shopManagerData.skinsBought;
        upgradeLevels = shopManagerData.upgradeLevels;
        boostsAmount = shopManagerData.boostsAmount;
        selectedSkin = shopManagerData.selectedSkin;
    }
}