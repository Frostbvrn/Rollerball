using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathHitbox : MonoBehaviour
{
    private static PlayerController playerController;
    private Rigidbody rb;
    public TextMeshProUGUI livesText;
    public GameObject lossTextObject;
    public GameObject playerBall;

    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            //transform.playerBall.position = playerController.startPos;

            //if(playerController.isGameWon == false)
            lives = lives - 1;
            SetLifeText();

            //rb.velocity = new Vector3(0.0f,0.0f,0.0f);
            Debug.Log("hit");
        }
        
    }
}
