using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text loseText;
    public Text winText;
    public Text countText;
    public Text livesText;
    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    public float speed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        loseText.text = "";
        lives = 3;
        winText.text = "";
        countText.text = "Count: " + count.ToString();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            countText.text = "Count: " + count.ToString();
            if (count >= 4)
            {
                winText.text = "You Win!";
            }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            livesText.text = "Lives: " + lives.ToString();
            if (lives <= 0)
            {
                loseText.text = "Game Over";
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                
            }
        }
    }
}
        
        
    



