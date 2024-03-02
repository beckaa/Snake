using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Snake : MonoBehaviour
{
    public GameObject head;
    public GameObject bodyPart;
    List<GameObject> body = new List<GameObject>();
    public Food food;
    //speed of the snake
    float speedX, speedY;
    Vector3 pos;
    int score;
    public GameObject endScreen;
    public TMP_Text scoreText;
    public AudioSource audioEat;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        body.Add(head);
        speedX = 1f;
        speedY = 0f;
        pos = new Vector3(speedX, 0, 0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        playerInput();

    }
    private void FixedUpdate()
    {
        //let the bodyparts follow the bodypart before them
        for (int i = body.Count - 1; i > 0; i--)
        {
            body[i].transform.position = body[i - 1].transform.position;
        }
        //moveSnake
        pos +=transform.position;
        transform.position = new Vector3(Mathf.Round(pos.x),Mathf.Round(pos.y),0);
    }
    void playerInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speedY = 1f;
            pos = new Vector3(0, speedY, 0);
            head.transform.eulerAngles = new Vector3(0, 0, 180);
            speedX = 0;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speedY = -1f;
            pos = new Vector3(0, speedY, 0);
            head.transform.eulerAngles = new Vector3(0, 0, 360);
            speedX = 0;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speedX = 1f;
            pos = new Vector3(speedX, 0, 0);
            head.transform.eulerAngles = new Vector3(0, 0, 90);
            speedY = 0;

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speedX = -1f;
            pos = new Vector3(speedX, 0, 0);
            head.transform.eulerAngles = new Vector3(0, 0, 270);
            speedY = 0;
        }
        else
        {
            pos = new Vector3(speedX, speedY, 0);
        }
    }

    /*
     * Snake eats food and grows taller
     */
    void eat()
    {
        //TODO sound
        audioEat.Play();
        //add points
        score += 10;

    }
    void grow()
    {
        GameObject segment = Instantiate(bodyPart);
        segment.transform.position = body[body.Count - 1].transform.position;
        body.Add(segment);
    }

    void endGame()
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
        scoreText.text = "Your Score is:  " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*detects the collision with food*/
        if (collision.tag == "Food")
        {
            Object.Destroy(collision.gameObject);
            eat();
            grow();
            food.instantiateNewFood();
        }

        /* TODO: Detect collision with wall (loose life)*/
        if(collision.tag == "wall")
        {
            endGame();
        }
    }
}
