using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;

    private int score = 0;

    public int health = 5;

    private Rigidbody player;

    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseImage;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            winLoseText.text = "Game Over!";
            winLoseText.color = Color.white;
            winLoseImage.color = Color.red;
            winLoseImage.gameObject.SetActive(true);

            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu");
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.AddForce(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            player.AddForce(0, 0, speed * -1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.AddForce(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            player.AddForce(speed * -1, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score++;
            SetScoreText();

            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
        }

        if (other.tag == "Goal")
        {
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            winLoseImage.color = Color.green;
            StartCoroutine(LoadScene(3));
        }
    }

    void SetScoreText()
    {
        scoreText.text = $"Score: {score.ToString()}";
    }

    void SetHealthText()
    {
        healthText.text = $"Health: {health.ToString()}";
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
