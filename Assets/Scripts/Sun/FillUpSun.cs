using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillUpSun : MonoBehaviour
{
    private HealthBar healthBarScript;
    private Animator animator;

    private float healSpeed = 80f;
    private bool shouldFillUpSun;

    private void Awake()
    {
        healthBarScript = GetComponent<HealthBar>();
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("SunFillUp");
    }   
}
