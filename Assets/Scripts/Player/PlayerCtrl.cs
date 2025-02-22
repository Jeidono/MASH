using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    public float movSpeed;
    public AudioSource Pickup;
    private float speedX, speedY;
    private Rigidbody2D rb;
    private bool isFacingRight = true; 

    private int honeyCounter = 0;
    private int honeyStorage = 0;
    private int totalHoneyCollected = 0;
    private const int maxCarry = 3;
    private const int winCondition = 8;
    private bool isInBase = false;

    public TMP_Text counterText;
    public TMP_Text totalHoneyText;
    public GameObject Uihoney1, Uihoney2, Uihoney3;
    public GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateUI();
    }

    void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.linearVelocity = new Vector2(speedX, speedY);

        if (speedX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (speedX < 0 && isFacingRight)
        {
            Flip();
        }

        if (isInBase && honeyCounter > 0 && Input.GetKeyDown(KeyCode.E))
        {
            DepositHoney();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Honey") && collision.gameObject.activeSelf && honeyCounter < maxCarry)
        {
            collision.gameObject.SetActive(false);
            honeyCounter++;
            Pickup.Play();
            UpdateUI();
        }
        else if (collision.CompareTag("Beehive1") || collision.CompareTag("Beehive2"))
        {
            isInBase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Beehive1") || collision.CompareTag("Beehive2"))
        {
            isInBase = false;
        }
    }

    private void DepositHoney()
    {
        honeyStorage += honeyCounter;
        totalHoneyCollected += honeyCounter;
        honeyCounter = 0;
        UpdateUI();
        CheckWinCondition();
    }

    void UpdateUI()
    {
        Uihoney1.SetActive(honeyCounter >= 1);
        Uihoney2.SetActive(honeyCounter >= 2);
        Uihoney3.SetActive(honeyCounter >= 3);
        counterText.text = "Storage: " + honeyStorage;
        totalHoneyText.text = "Total Honey: " + totalHoneyCollected;
    }

    void CheckWinCondition()
    {
        if (honeyStorage >= winCondition)
        {
    
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameManager.WinScreen();
            Debug.Log("You Win!");
        }
    }
}
