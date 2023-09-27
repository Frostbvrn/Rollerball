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
    public GameObject winTextObject;
    public GameObject lossTextObject;
    public GameObject playerBall;
    public GameObject cam;
    public float jumpForce = 5;

    private Rigidbody rb;
    private int count;
    private int lives;
    private bool isGameWon;
    private float movementX;
    private float movementY;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        isGameWon = false;

        SetCountText();
        winTextObject.SetActive(false);
        lossTextObject.SetActive(false);

        startPos = transform.position;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //void OnLook(InputValue rot)
    //{
    //    Vector2 inputRot=rot.Get<Vector2>();
    //    Vector3 camRot=cam.transform.rotation.eulerAngles;
    //    camRot.x+=inputRot.y;
    //    camRot.y+=inputRot.x;
    //    cam.transform.rotation=Quaternion.Euler(camRot);
    //}

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 16)
        {
            winTextObject.SetActive(true);
            isGameWon = true;
        }

        livesText.text = "Lives: " + lives.ToString();
        //if(win == 0)
        // {return;}
        if (lives <= 0)
        {
            lossTextObject.SetActive(true);
            playerBall.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }

        if(other.gameObject.CompareTag("Death"))
        {
            transform.position = startPos;

            if(isGameWon == false)
            lives = lives - 1;
            SetCountText();

            rb. velocity = new Vector3(0.0f,0.0f,0.0f);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {  
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
         transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);

        if (Physics.Raycast(transform.position, Vector3.down, 0.4f))
        {
            transform.position = startPos;

            if(isGameWon == false)
            lives = lives - 1;
            SetCountText();

            rb. velocity = new Vector3(0.0f,0.0f,0.0f);
        }
    }
}

