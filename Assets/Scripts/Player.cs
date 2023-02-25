using UnityEngine;
using System.Collections.Generic;
using GG.Infrastructure.Utils.Swipe;
using UnityEngine.U2D.Animation;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool canMove;
    [HideInInspector] public bool canAddPlayingSeconds;
    [HideInInspector] public float speed;
    [HideInInspector] public int score;
    [HideInInspector] public int totalSecondsPlayed;

    [Header("SpriteLibraryAsset")]
    [SerializeField] private List<SpriteLibraryAsset> skins;
    [SerializeField] private SpriteLibrary spriteLibraryScript;

    [Header("Components")]
    public Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("GameObjects")]
    [SerializeField] private GameObject trophy;
    [SerializeField] private GameObject GameOverCanvas;

    [Header("Upgrades")]
    [SerializeField] private List<float> speeds;

    [Header("AudioClips")]
    [SerializeField] private AudioClip borderSXF;
    [SerializeField] private AudioClip trophySFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip movementSFX;

    [Header("Scripts")]
    [SerializeField] private ScoreTextsCanvas scoreTextsCanvasScript;
    [SerializeField] private HealthBar healthBarScript;
    [SerializeField] private Confetti confettiScript;
    [SerializeField] private SwipeListener swipeListenerScript;
    [SerializeField] private TrophiesSpawner trophiesSpawnerScript;
    [SerializeField] private ObstaclesSpawner obstaclesSpawnerScript;
    [SerializeField] private SnowExplosion snowExplosionScript;
    [SerializeField] private InventoryItemsSpawner inventoryItemsSpawnerScript;

    private Vector2 moveInput;
    private string swipeDirection;
    private bool obstaclesOn;
    private bool shieldOn;
    private bool particlesOn;
    private int trophiesCollected;
    private int trophiesMultiplier;
    private float scaleValue = 2.884061f;
    private float resistance;
    private float verticalMovement;
    private float horizontalMovement;

    #region Start

    private void Start()
    {
        swipeListenerScript.OnSwipe.AddListener(OnSwipe);
        speed = 3.75f;
        particlesOn = PlayerPrefs.GetString("ParticlesStatus") == "On";

        if(SaveManager.LoadShopManagerData() != null)
        {
            ShopManager.LoadData();
            ShopManager.skinsBought.Add(1);
        }

        SetSkin();
        SetSpeed();
        SetResistance();
        CheckBoosts();
    }

    private void SetSkin()
    {
        if(ShopManager.selectedSkin != 0)
        {
            spriteLibraryScript.spriteLibraryAsset = skins[ShopManager.selectedSkin - 1];
        }
    }

    private void SetSpeed()
    {
        speed = speeds[ShopManager.upgradeLevels["Velocity"] - 1];
    }

    private void SetResistance()
    {
        for (int i = 0; i < ShopManager.upgradeLevels["Resistance"]; i++)
        {
            resistance += .08f;
        }
    }

    private void CheckBoosts()
    {
        if(ShopManager.boostsAmount["DoubleTrophies"] >= 1)
        {
            ShopManager.boostsAmount["DoubleTrophies"] -= 1;
            trophiesMultiplier = 2;
        }
        else
        {
            trophiesMultiplier = 1;
        }

        if(ShopManager.boostsAmount["Shield"] >= 1)
        {
            ShopManager.boostsAmount["Shield"] -= 1;
            shieldOn = true;
        }
        else
        {
            shieldOn = false;
        }

        if(ShopManager.boostsAmount["NoObstacles"] >= 1)
        {
            ShopManager.boostsAmount["NoObstacles"] -= 1;
            obstaclesOn = false;
        }
        else
        {
            obstaclesOn = true;
        }

        SaveManager.SaveShopManagerData();
    }

    #endregion

    #region Update

    private void Update() 
    {
        Move();
        Animate();
    }

    public void SetPlayedSeconds()
    {
        InvokeRepeating("AddPlayedSeconds", 1f, 1f);
    }

    private void AddPlayedSeconds()
    {
        if(canAddPlayingSeconds)
        {
            totalSecondsPlayed += 1;
        }
    }

    private void Move()
    {
        if(canMove)
        {
            transform.position += (Vector3)moveInput * speed * Time.deltaTime;
        }
    }

    private void OnSwipe(string swipe)
    {
        if(canMove)
        {
            if(swipe != swipeDirection)
            {
                AudioManager.instance.PlaySFX(movementSFX);
            }

            if(swipe == "Left")
            {
                moveInput = Vector2.left;
                swipeDirection = "Left";
            }        
            if(swipe == "Right")
            {
                moveInput = Vector2.right;
                swipeDirection = "Right";
            }        
            if(swipe == "Up")
            {
                moveInput = Vector2.up;
                swipeDirection = "Up";
            }        
            if(swipe == "Down")
            {
                moveInput = Vector2.down;
                swipeDirection = "Down";
            }
        }
    }

    #endregion

    #region Animate

    private void Animate()
    {
        animator.SetBool("Running", moveInput.x != 0.0f && canMove);
        animator.SetBool("Back", moveInput.y == 1 && canMove);
        animator.SetBool("Front", moveInput.y == -1 && canMove);
        RotateX();
    }

    private void RotateX()
    {
        if(moveInput.x < 0)
        {
            transform.localScale = new Vector3(-scaleValue, transform.localScale.y, scaleValue);
        }
        else if(moveInput.x > 0)
        {
            transform.localScale = new Vector3(scaleValue, transform.localScale.y, scaleValue);
        }
    }

    #endregion

    #region OnTrigger2D

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Trophy"))
        {
            AudioManager.instance.PlaySFX(trophySFX);
            other.GetComponent<Trophy>().StartCollectedTrophyAnimation();
            trophiesCollected += 1;
            GameManager.IncreaseCups(trophiesMultiplier);
            score += 1 * trophiesMultiplier;
            AnalyticsManager.IncreaseTotalTrophies(1 * trophiesMultiplier);
            scoreTextsCanvasScript.UpdateScoreText(score);
            
            if(trophiesCollected == TrophiesSpawner.level)
            {
                trophiesCollected = 0;
                healthBarScript.health = 100f;
                TrophiesSpawner.level += 1;
                scoreTextsCanvasScript.UpdateLevelText();
                scoreTextsCanvasScript.LevelCompleted();
                inventoryItemsSpawnerScript.CheckSpawnInventoryItems();
                trophiesSpawnerScript.SpawnTrophies();

                if(TrophiesSpawner.level >= 16 && !obstaclesOn)
                {
                    obstaclesOn = true;
                }

                if(obstaclesOn == true)
                {
                    obstaclesSpawnerScript.SpawnObstacles();
                }

                if(particlesOn)
                {
                    confettiScript.LaunchConfetti();
                }
            }
            else
            {
                scoreTextsCanvasScript.Scored();
            }
        }      

        if(other.gameObject.CompareTag("FitToThis"))
        {
            AudioManager.instance.PlaySFX(borderSXF);

            if(swipeDirection == "Left" || swipeDirection == "Right")
            {
                moveInput.x *= -1;
            }

            if(swipeDirection == "Up" || swipeDirection == "Down")
            {
                moveInput.y *= -1;
            }
        }  

        if(other.CompareTag("Mud"))
        {
            speed /= 2 - resistance;
            Color muddyColor;
            ColorUtility.TryParseHtmlString("#8F563B", out muddyColor);
            spriteRenderer.color = muddyColor;
        }

        if(other.CompareTag("Ice"))
        {
            snowExplosionScript.CreateSnowExplosion(other.gameObject.transform.position);
            Destroy(other.gameObject);
            animator.SetBool("Frozen", true);
            canMove = false;
            Color frozenColor;
            ColorUtility.TryParseHtmlString("#00AEE0", out frozenColor);
            spriteRenderer.color = frozenColor;
            Invoke("Defrost", 1.2f);
        }

        if(other.CompareTag("FrancePlayer"))
        {
            if(!shieldOn)
            {
                other.GetComponent<FrancePlayer>().OnPlayerCollided();
                GameOver();
            }

            if(shieldOn)
            {
                other.GetComponent<FrancePlayer>().OnPlayerCollidedWithShieldOn();
                shieldOn = false;
            }
        }
    }

    private void Defrost()
    {
        animator.SetBool("Frozen", false);
        canMove = true;
        spriteRenderer.color = Color.white;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Mud"))
        {
            speed *= 2 - resistance;
            spriteRenderer.color = Color.white;
        }
    }

    #endregion

    #region GameOver

    public void GameOver()
    {
        AudioManager.instance.PlaySFX(deathSFX);
        canMove = false;
        canAddPlayingSeconds = false;
        boxCollider.enabled = false;
        animator.SetBool("Dead", true);
        spriteRenderer.color = Color.white;
        ApplyDeathImpulse();
        Invoke("ShowGameOverCanvas", 2);
    }

    private void ApplyDeathImpulse()
    {
        rb.gravityScale = 3;
        rb.AddForce(Vector2.up * 8, ForceMode2D.Impulse);
    }

    private void ShowGameOverCanvas()
    {
        GameOverCanvas.SetActive(true);
    }

    #endregion
}