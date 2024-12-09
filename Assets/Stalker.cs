using UnityEngine;
using UnityEngine.UI; 

public class StalkerAI : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 
    public GameObject gameOverUI; 

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f; 
        gameOverUI.SetActive(true); 
    }
}
