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
    public GameObject Beam;
    public float jumpForce = 5;

    private Rigidbody rb;
    static int count;
    public int lives;
    public bool isGameWon;
    private float movementX;
    private float movementY;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = 3;
        isGameWon = false;

        SetCountText();
        SetLifeText();
        winTextObject.SetActive(false);
        lossTextObject.SetActive(false);
        Beam.SetActive(false);

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

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.CompareTag("Pickup"))
        //{
        //    other.gameObject.SetActive(false);
        //    count = count + 1;

        //    SetCountText();
        //}

        //if(other.gameObject.CompareTag("Death"))
        //{
        //    transform.position = startPos;

        //    if(isGameWon == false)
        //    lives = lives - 1;
        //    SetLifeText();

        //    rb. velocity = new Vector3(0.0f,0.0f,0.0f);
        //}
        
    }

    void Update()
    {
        // Bounces up player when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            {  
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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

        //if (Physics.Raycast(transform.position, Vector3.down, 0.4f))
        //{
        //    transform.position = startPos;

        //    if(isGameWon == false)
        //    lives = lives - 1;
        //    SetLifeText();

        //    rb. velocity = new Vector3(0.0f,0.0f,0.0f);
        //}
    }
}

