using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : MonoBehaviour
{
    private float _speed;
    private float _height;
    

    GameManager gameManager;
    private GameObject _ball;
   

    void Start()
    {
       _ball = GameObject.FindGameObjectWithTag("Ball");
        
        _height = transform.localScale.y;
        _speed = 26f;

    }

    private void Update()
    {
        Vector2 paddlePos = transform.position;

        if(paddlePos.y >= GameManager.topRight.y)
        {
            paddlePos.y = GameManager.topRight.y - _height;
        }
        else if(paddlePos.y < GameManager.bottomLeft.y)
        {
            paddlePos.y = GameManager.bottomLeft.y + _height;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       Vector2 pos = transform.position;

        pos.y = _ball.transform.position.y * _speed * Time.deltaTime;
       

        transform.position = pos;
       
    }

    
}
