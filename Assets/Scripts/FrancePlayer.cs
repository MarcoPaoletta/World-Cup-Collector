using UnityEngine;

public class FrancePlayer : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;

    private Vector2 moveInput;
    private ObstaclesSpawner obstaclesSpawnerScript;
    private float speed = 2.5f;
    private int random;
    private bool canMove = true;

    private void Start()
    {
        obstaclesSpawnerScript = GameObject.FindObjectOfType<ObstaclesSpawner>();

        if(obstaclesSpawnerScript.francePlayerState == "Idle")
        {
            canMove = false;
            return;
        }

        if(obstaclesSpawnerScript.francePlayerState == "Walk")
        {
            SetInitialDirection();
            CheckFlip();
            SetPositionY();
            EnableWalkAnimation();
        }
    }

    private void SetInitialDirection()
    {
        random = Random.Range(1, 3);
        moveInput = random == 1 ? Vector2.left : Vector2.right;
    }

    private void CheckFlip()
    {
        spriteRenderer.flipX = moveInput.x == -1 ? true : false;
    }

    private void SetPositionY()
    {
        Vector3 position = transform.position;
        position.y = obstaclesSpawnerScript.obstaclePosition.y;
        transform.position = position;
    }

    private void EnableWalkAnimation()
    {
        animator.SetBool("Walk", true);
    }

    private void Update()
    {
        if(canMove)
        {
            transform.position += (Vector3)moveInput * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("FitToThis"))
        {
            if(moveInput.x == 1 || moveInput.x == -1)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                moveInput.x *= -1;
            }

            if(moveInput.y == 1 || moveInput.y == -1)
            {
                spriteRenderer.flipY = !spriteRenderer.flipY;
                moveInput.y *= -1;
            }
        }
    }

    public void OnPlayerCollided()
    {
        animator.SetBool("Happy", true);
        animator.SetBool("Walk", false);
        canMove = false;
    }

    public void OnPlayerCollidedWithShieldOn()
    {
        boxCollider.enabled = false;
        animator.SetBool("Dead", true);
        ApplyDeathImpulse();
    }

    private void ApplyDeathImpulse()
    {
        rb.gravityScale = 3;
        rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
        Invoke("FrenchDeath", 2);
    }

    private void FrenchDeath()
    {
        Destroy(gameObject);
    }
}