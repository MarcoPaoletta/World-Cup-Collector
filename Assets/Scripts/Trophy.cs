using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void OnCollectedAnimationFinished()
    {
        Destroy(gameObject);
    }

    public void StartCollectedTrophyAnimation()
    {
        boxCollider.enabled = false;
        animator.StopPlayback();
        animator.Play("Collected");
        spriteRenderer.sortingOrder = 1100;
    }
} 