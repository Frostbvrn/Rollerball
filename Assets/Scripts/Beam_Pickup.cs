using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beam_Pickup : MonoBehaviour
{
    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    public GameObject scoreTextObject;
    public TextMeshProUGUI scoreText;
    public PlayerController pC;

    static int count;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        score = 100000;
    }

    // Update is called once per frame
    void Update()
    {   
        if(pC.isGameWon == false)
        {
        score = score - 1;
        }
    }

    void SetCountText()
    {
        countText.text = "Cows: " + count.ToString();
        if(count >= 7 && pC.isGameWon == false)
        {
            winTextObject.SetActive(true);
            pC.isGameWon = true;
            scoreTextObject.SetActive(true);
            scoreText.text = "Score: " + score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 15000;
            SetCountText();
        }
    }
}
