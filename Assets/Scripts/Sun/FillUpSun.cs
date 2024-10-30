using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillUpSun : MonoBehaviour
{
    private HealthBar healthBarScript;

    private float healSpeed = 55f;
    private bool shouldFillUpSun;

    private void Awake()
    {
        healthBarScript = GetComponent<HealthBar>();
    }

    private void Update()
    {
        if (!shouldFillUpSun)
        {
            return;
        }

        healthBarScript.health += healSpeed * Time.deltaTime;

        if (healthBarScript.health >= 100f)
        {
            shouldFillUpSun = false;
        }
    }

    public void LevelCompleted()
    {
        shouldFillUpSun = true;
    }   
}
