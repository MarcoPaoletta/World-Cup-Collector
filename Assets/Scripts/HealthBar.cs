using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;

    [SerializeField] private Image sun;
    [SerializeField] private Player playerScript;

    private int checkDeadTimesCalled;
    private float clockDuration;
    private float maxHealth = 100f;

    private void Start()
    {
        health = 100f;
        SetClockDuration();
    }

    private void SetClockDuration()
    {
        SaveManager.LoadShopManagerData();

        for (int i = 0; i < ShopManager.upgradeLevels["ClockDuration"]; i++)
        {
            clockDuration = .5f * i;
        }
    }

    private void Update()
    {
        DecreaseHealth();
        CheckDead();
    }

    private void DecreaseHealth()
    {
        if(health > 0 && playerScript.canMove || isPlayerFrozen())
        {
            sun.fillAmount = health / maxHealth;
            health -= (9f - clockDuration) * Time.deltaTime;
        }
    }

    private bool isPlayerFrozen()
    {
        return playerScript.animator.GetBool("Frozen");
    }

    private void CheckDead()
    {
        if(health <= 0 && checkDeadTimesCalled != 1)
        {
            checkDeadTimesCalled += 1;
            playerScript.GameOver();
            Destroy(gameObject);
            SetFrancePlayerHappy();
        }
    }
    
    private void SetFrancePlayerHappy()
    {
        if(GameObject.FindObjectOfType<FrancePlayer>())
        {
            GameObject.FindObjectOfType<FrancePlayer>().OnPlayerCollided();
            playerScript.GameOver();
        }
    }
}