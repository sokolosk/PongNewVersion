using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start1Player : MonoBehaviour
{

    public static bool AIPaddle = false;
    public static bool Paddle2 = false;


    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        
    }

    private void OnGUI()
    {
        GUI.backgroundColor = Color.clear;
        if (GUI.Button(new Rect(200, 205, 240, 40), ""))
        {
            print("AIPaddle");
            AIPaddle = true;
        }

        else if (GUI.Button(new Rect(200, 260, 240, 40), ""))
        {
            print("Paddle2");
            AIPaddle = false;


        }
    }


}
