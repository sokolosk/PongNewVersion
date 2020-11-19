using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    private float _speed;
    private float _height;
    float paddle2;


    // Start is called before the first frame update

    void Start()
    {
        _height = transform.localScale.y;
        _speed = 15f;

    }


    // Update is called once per frame
    private void Update()
    {
        MovePaddle2();
    }

    void MovePaddle2()
    {
        float paddle2 = Input.GetAxisRaw("Vertical2") * Time.deltaTime * _speed;
        transform.position = new Vector3(transform.position.x, transform.position.y + paddle2, transform.position.z);

        Vector2 paddlePos = transform.position;

        if (paddlePos.y >= GameManager.topRight.y)
        {
            paddlePos.y = GameManager.topRight.y - _height;
        }
        else if (paddlePos.y < GameManager.bottomLeft.y)
        {
            paddlePos.y = GameManager.bottomLeft.y + _height;
        }
        transform.position = paddlePos;
    }

   
}