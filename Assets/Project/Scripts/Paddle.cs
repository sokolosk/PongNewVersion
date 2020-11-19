using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private float _speed;
    private float _height;
    float paddle1;


    // Start is called before the first frame update

    void Start()
    {
        _height = transform.localScale.y;
        _speed = 15f;

    }


    // Update is called once per frame
    private void Update()
    {
        float paddle1 = Input.GetAxisRaw("Vertical1") * Time.deltaTime * _speed;
        transform.position = new Vector3 (transform.position.x, transform.position.y + paddle1, transform.position.z);

        
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
