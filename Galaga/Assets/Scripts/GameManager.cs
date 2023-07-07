using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public PlayerBullet playerBullet;

    public Text timeText;
    public Text timeRecordText;


    public Text KillCountText;
    public Text KillRecordText;


    public static int killCount;
    private float surviveTime;
    private bool isGameover;


    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        killCount = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) 
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;

            KillCountText.text = "Score: " + killCount;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("PlayScene");
        }
    }

    public void EndGame() 
    {
        isGameover = true;

        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        int bestScore = PlayerPrefs.GetInt("BestScore");
        
        if(surviveTime > bestTime) 
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        if(killCount > bestScore) 
        {
            bestScore = killCount;

            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        timeRecordText.text = "Best Time: " +  (int)bestTime;

        KillRecordText.text = "Best Score: " + bestScore;
    }
}
