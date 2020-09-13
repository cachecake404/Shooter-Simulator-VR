using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AliveTimeTracker : MonoBehaviour
{
    private float timeAlive = 0f;
    public TextMeshProUGUI message;
    // Start is called before the first frame update
    void Start()
    {
        timeAlive = PlayerPrefs.GetFloat("TimeAlive");
        message.text = "GAME OVER\nYou survived for " + timeAlive.ToString() + " seconds!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
