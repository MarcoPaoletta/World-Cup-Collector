using UnityEngine;

public class TrophyParticles : MonoBehaviour
{
   [SerializeField] private ParticleSystem particles;

    private void Update()
    {
        if(!particles.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}