using System.Collections.Generic;

[System.Serializable] // turn on serialization so that we can turn the data of this script into binary and save it
public class GameManagerData
{
    public int cups;
    public int bestLevel;

    public GameManagerData()
    {
        cups = GameManager.cups;
        bestLevel = GameManager.bestLevel;
    }
}