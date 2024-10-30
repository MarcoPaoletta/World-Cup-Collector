using System.Collections.Generic;

[System.Serializable] // turn on serialization so that we can turn the data of this script into binary and save it
public class ShopManagerData
{
    public List<int> skinsBought = new List<int>();
    public Dictionary<string, int> upgradeLevels = new Dictionary<string, int>()
    {
        {"Velocity", 1},
        {"ClockDuration", 1},
        {"Resistance", 1},
        {"GuardianAngel", 1}
    };
    
    public Dictionary<string, int> boostsAmount = new Dictionary<string, int>()
    {
        {"DoubleTrophies", 0},
        {"Shield", 0},
        {"NoObstacles", 0},
    };

    public int selectedSkin;

    public ShopManagerData()
    {
        skinsBought = ShopManager.skinsBought;
        upgradeLevels = ShopManager.upgradeLevels;
        boostsAmount = ShopManager.boostsAmount;
        selectedSkin = ShopManager.selectedSkin;
    }
}