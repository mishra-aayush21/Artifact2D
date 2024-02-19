using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    public float timeToWin = 300f;

    private bool gameOver;

    private GameObject artifact;
    private StringBuilder stringBuilder;

    private void Awake()
    {
        artifact = GameObject.FindWithTag("Artifact");
        stringBuilder = new StringBuilder();
    }

    private void Update()
    {
        if (gameOver || !artifact) return;

        timeToWin-=Time.deltaTime;

        if(timeToWin <= 0)
        {
            timeToWin = 0;
            gameOver = true;
            Destroy(artifact);

            //show win panel
            GameOverController.instance.GameOver("Yeah Boii!");

        }
        //timerText.text = "Time Remaining:" + (int)timeToWin;



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOverController.instance.GameOver("Paused");
        }
        DisplayTime((int)timeToWin);



        
    }//update

    void DisplayTime(int time)
    {
        stringBuilder.Length = 0;
        stringBuilder.Append("Time Remaining: ");
        stringBuilder.Append(time);

        timerText.text = stringBuilder.ToString();

    }























}//class
