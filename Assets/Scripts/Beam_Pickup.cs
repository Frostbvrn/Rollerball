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
    public int score = 0;
    public int cowBonus = 0;
    public int goalCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(pC.isGameWon == false)
        {
        score = score - 5;
        }
    }

    void SetCountText()
    {
        countText.text = "Cows: " + count.ToString();
        if(count >= goalCount && pC.isGameWon == false)
        {
            winTextObject.SetActive(true);
            pC.isGameWon = true;
            if (score < 0)
            {
                score = 0;
            }
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
            score = score + cowBonus;
            SetCountText();
        }
    }
}
