using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    GameManager gameManager;


    private float ballPosY;
    

    [SerializeField] private float _moveSpeed = 6f; //velocidade da bola
    [SerializeField] private float _maxBounceAngle = 45f; //angulo maximo bounce da bola
    
    // Start is called before the first frame update
    void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody2D>();

        Vector2[] direction = { Vector2.right, Vector2.left };
        int index = Random.Range(0, 2);

        _velocity = direction[index] * _moveSpeed;
    }

    private void Update()
    {
        ballPosY = transform.position.y;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        _rb.velocity = _velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Paddle") // detectar colisao da bola com a raquete
        {
            BounceFromPaddle(collision.collider);
            _moveSpeed++;

        }
        else
        {
            Bounce();
            _moveSpeed++;

        }
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "P1Point")
        {
            gameManager.IncreaseP1Score();
            //Debug.Log("point");
            ResetBall();
            Invoke("NewPoint", 0.5f);
        }

        else if (collision.tag == "P2Point")
        {
            gameManager.IncreaseP2Score();
            //Debug.Log("point");
            ResetBall();
            Invoke("NewPoint", 0.5f);
        
            }
    }


    public void ResetBall()
    {

        //Debug.Log("reset");
        _rb.transform.position = Vector2.zero;
        _velocity = Vector2.zero;
        _moveSpeed = 6.0f;
    }

    void NewPoint()
        {
       // Debug.Log("newpoint");
        _rb.velocity = _velocity;

        Vector2[] direction = { Vector2.right, Vector2.left };
        int index = Random.Range(0, 2);

        _velocity = direction[index] * _moveSpeed;

    }

    
   

    private void Bounce()
    {
        _velocity = new Vector2(_velocity.x, -_velocity.y);
    }
    private void BounceFromPaddle(Collider2D collider) //metodo para definir bounce da bola com raquete
    {
        float colYExtent = collider.bounds.extents.y; // exten'ão do collider
        float yOffset = transform.position.y - collider.transform.position.y; // offset do collider da raquete com a bola

        float yRatio = yOffset / colYExtent; // angulo offset da bola divido pela extenção da raquete
        float bounceAngle = _maxBounceAngle * yRatio * Mathf.Deg2Rad; //definir angulo bounce conforme posiçao da colisao

        Vector2 bounceDirection = new Vector2(Mathf.Cos(bounceAngle), Mathf.Sin(bounceAngle)); //utiliza o seno e cos do angulo para determinar a direçao da bola após colisão.

        bounceDirection.x *= Mathf.Sign(-_velocity.x); // mudar direcao da velocidade após colisao

        _velocity = bounceDirection * _moveSpeed; // alterar velocidade após impacto
    }
}
