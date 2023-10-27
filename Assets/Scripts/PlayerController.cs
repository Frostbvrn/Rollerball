using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    public GameObject lossTextObject;
    public GameObject scoreTextObject;
    public GameObject playerBall;
    public GameObject Beam;
    public float jumpForce = 5;
    private Rigidbody rb;
    static int count;
    public int lives;
    public int score;
    public bool isGameWon;
    private float movementX;
    private float movementY;
    public Vector3 startPos;
    private ConstantForce cForce;
    private Vector3 forceStrength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        score = 0;
        isGameWon = false;

        SetCountText();
        SetLifeText();
        winTextObject.SetActive(false);
        lossTextObject.SetActive(false);
        scoreTextObject.SetActive(false);
        Beam.SetActive(false);

        startPos = transform.position;

        cForce = GetComponent<ConstantForce>();
        forceStrength = new Vector3(0f, -9.81f, 0f);
        cForce.force = forceStrength;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void SetCountText()
    {
        countText.text = "Cows: " + count.ToString();
        if(count >= 7)
        {
            winTextObject.SetActive(true);
            isGameWon = true;
            scoreTextObject.SetActive(true);
        }
    }
    public void SetLifeText()
    {
        livesText.text = "Lives: " + lives.ToString();
        //if(win == 0)
        // {return;}
        if (lives <= 0)
        {
            lossTextObject.SetActive(true);
            playerBall.SetActive(false);
        }
    }

    public void resetPos()
    {
        transform.position = startPos;
        rb. velocity = new Vector3(0.0f,0.0f,0.0f);
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (PauseMenu.isPaused == false)
        {
        // Bounces up player when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            {  
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }

        // Speeds up descent when shift is held
        if (Input.GetKey(KeyCode.LeftShift))
            {  
                forceStrength = new Vector3(0f, -19.62f, 0f);
                cForce.force = forceStrength;
            }
        else
            {
                forceStrength = new Vector3(0f, -9.81f, 0f);
                cForce.force = forceStrength;
            }
        
        // Toggles tractor beam
        if (Input.GetMouseButtonDown(0))
            {  
                Beam.SetActive(true);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Beam.SetActive(false);
            }
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        }
    }
}

