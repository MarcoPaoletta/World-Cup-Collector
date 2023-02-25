using UnityEngine;
using System.Collections.Generic;

public class Confetti : MonoBehaviour
{
    private ParticleSystem[] confettiArray;
    private List<ParticleSystem> confettiParticles = new List<ParticleSystem>();

    private void Start()
    {
        confettiArray = GetComponentsInChildren<ParticleSystem>();

        foreach(var confetti in confettiArray)
        {
            confettiParticles.Add(confetti);
        }
    }

    public void LaunchConfetti()
    {
        foreach(var confetti in confettiParticles)
        {
            confetti.Play();
        }
    }
}