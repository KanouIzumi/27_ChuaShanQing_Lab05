using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_Win_Lose_Score_Script : MonoBehaviour
{
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_GetCoin;           // the sound played when character touches the coin.

    //This is for the score 
    public Text scoreText;
    private GameObject[] coins;
    private int score;

    //this is for the time
    public float timeleft;
    public float timeRemaining;
    public Text TimerText;
    private float TimerValue;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;

        timeRemaining = Mathf.FloorToInt(timeleft % 60);

        TimerText.text = "Timer :" + timeRemaining.ToString();

        if(coins.Length <= 0)
        {
            if(timeleft <=TimerValue)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }

        else if(timeleft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }

        //WinCondition();
    }

    private void PlayGetCoinsound()
    {
        m_AudioSource.clip = m_GetCoin;
        m_AudioSource.Play();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score +=10;
            scoreText.text = "Score: " + score;
            PlayGetCoinsound();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Water")
        {
            print("You touch Water");
            SceneManager.LoadScene("GameLoseScene");
        }

    }

    //How to win the game
    //private void WinCondition()
    //{
    //    coins = GameObject.FindGameObjectsWithTag("Coin");

    //    if (coins.Length <= 0)
    //    {
    //        SceneManager.LoadScene("GameWinScene");
    //    }
    //}
}
