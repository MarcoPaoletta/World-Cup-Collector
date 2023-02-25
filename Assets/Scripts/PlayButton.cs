using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        AnalyticsManager.IncreaseMatchesPlayed();
    }
}