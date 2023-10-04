using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beam_Pickup : MonoBehaviour
{
    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    public PlayerController pC;

    static int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 5)
        {
            winTextObject.SetActive(true);
            pC.isGameWon = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
