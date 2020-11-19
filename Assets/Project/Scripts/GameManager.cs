using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Transform spawnPos1;
    public Transform spawnPos2;
    public static Vector2 topRight;
    public static Vector2 bottomLeft;

    public Ball ball;
    public Paddle paddle1;
    public Paddle paddle2;
    public PaddleAI paddleAI;


    public bool bot;
    public static bool aiPaddle;

    [HideInInspector] public int _player1Score;
    [HideInInspector] public int _player2Score;

    public Text _p1Score;
    public Text _p2Score;

    GameObject[] pauseObjects;


    private void Awake()
    {
        aiPaddle = GetComponent<Start1Player>();
        

    }

    void Start()
    {

        
        aiPaddle = FindObjectOfType<Start1Player>();
        bot = Start1Player.AIPaddle;
        

        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        InstantiateBall();

        Instantiate(paddle1,spawnPos1.position, spawnPos1.rotation);

        if(bot == true)
        {
            paddleAI = Instantiate(paddleAI, spawnPos2.position, spawnPos2.rotation);
        }

        else
        {
            paddle2 = Instantiate(paddle2, spawnPos2.position, spawnPos2.rotation);
        }

        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale ==1)
            {
                Time.timeScale = 0;
                ShowPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                HidePaused();
            }
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene("Game");
        
    }

    public void PauseControl()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else if(Time.timeScale ==0)
        {
            Time.timeScale = 1;
            HidePaused();
        }

    }

    public void ShowPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    public void HidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    public void LoadLevel(string Menu)
    {
        SceneManager.LoadScene("Menu");
    }

    public void InstantiateBall()
    {

        Vector3 ballPosition = new Vector3(0,0,0);
        Instantiate(ball, ballPosition, Quaternion.identity);
    }

    public void IncreaseP1Score()
    {
        _player1Score = _player1Score + 1;
        _p1Score.text = _player1Score.ToString();
        print(_player1Score + " , " + _player2Score);
    }

    public void IncreaseP2Score()
    {
        _player2Score = _player2Score + 1;
         _p2Score.text = _player2Score.ToString();
        print(_player1Score + " , " + _player2Score);
    }

}
