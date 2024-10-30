using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static int cups;
    public static int bestLevel;

    public static GameManager instance;

    private void Awake()
    {
        if(GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void IncreaseCups(int trophiesMultiplier)
    {
        cups += 1 * trophiesMultiplier;
        SaveManager.SaveGameManagerData();
    }

    public static void LoadData()
    {
        GameManagerData gameManagerData = SaveManager.LoadGameManagerData();
        cups = gameManagerData.cups;
        bestLevel = gameManagerData.bestLevel;
    }
}