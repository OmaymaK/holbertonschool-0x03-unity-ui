using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Rigidbody player;
    public Text winlosetext;
    public Image winlosebg;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (Input.GetKey("up"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);
        }
        if (Input.GetKey("right"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
        }
        if (Input.GetKey("down"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -speed);
        }
        if (Input.GetKey("left"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
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
            health -= 1;
            SetHealthText();
        }
        if (other.tag == "Goal")
        {
            winlosetext.text = "You Win!";
            winlosetext.color = Color.black;
            winlosebg.color = Color.green;
            winlosebg.gameObject.SetActive(true);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("maze");
        }
    }
    
    void SetScoreText()
    {
        scoreText.text = "Score: " + this.score.ToString();
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + this.health.ToString();
    }
}