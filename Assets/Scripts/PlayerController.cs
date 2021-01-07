using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;

    private int score = 0;

    public int health = 5;

    private Rigidbody player;

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
            Debug.Log("Game Over!");
            health = 5;
            score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            Debug.Log($"Score: {score}");

            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }

        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
}
