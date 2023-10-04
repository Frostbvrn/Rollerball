using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathHitbox : MonoBehaviour
{
    public PlayerController pC;
    private Rigidbody rb;
    public TextMeshProUGUI livesText;
    public GameObject lossTextObject;
    public GameObject playerBall;
    public Vector3 startPos;

    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        startPos = playerBall.transform.position;
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
            playerBall.transform.position = startPos;

            if(pC.isGameWon == false)
            {
            lives = lives - 1;
            SetLifeText();
            }

            //rb.velocity = new Vector3(0.0f,0.0f,0.0f);
            Debug.Log("hit");
        }
        
    }
}
