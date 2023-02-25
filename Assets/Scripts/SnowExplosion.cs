using UnityEngine;

public class SnowExplosion : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void CreateSnowExplosion(Vector3 snowFlakePosition)
    {
        transform.position = snowFlakePosition;
        ShowExplosion();
        Invoke("HideExplosion", .063f);
    }

    private void ShowExplosion()
    {
        Color spriteRendererColor = spriteRenderer.color;
        spriteRendererColor.a = 255;
        spriteRenderer.color = spriteRendererColor;
    }

    private void HideExplosion()
    {
        Color spriteRendererColor = spriteRenderer.color;
        spriteRendererColor.a = 0;       
        spriteRenderer.color = spriteRendererColor;
    }
}