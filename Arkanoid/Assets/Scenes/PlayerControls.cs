using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f; // Velocidade da raquete
    private float leftBound, rightBound; // Limites laterais

    private Rigidbody2D rb2d;
    private float paddleWidth;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Obtém os limites das paredes
        GameObject leftWall = GameObject.Find("LeftWall");
        GameObject rightWall = GameObject.Find("RightWall");

        if (leftWall && rightWall)
        {
            float leftLimit = leftWall.transform.position.x + leftWall.GetComponent<BoxCollider2D>().bounds.extents.x;
            float rightLimit = rightWall.transform.position.x - rightWall.GetComponent<BoxCollider2D>().bounds.extents.x;

            paddleWidth = GetComponent<BoxCollider2D>().bounds.extents.x; // Metade da largura da raquete

            leftBound = leftLimit + paddleWidth;   // Ajusta para considerar a largura da raquete
            rightBound = rightLimit - paddleWidth; // Ajusta para considerar a largura da raquete
        }
    }

    void Update()
    {
        float move = 0;

        // Controle apenas no eixo X com as teclas A e D
        if (Input.GetKey(KeyCode.A))
        {
            move = -speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = speed * Time.deltaTime;
        }

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + move, leftBound, rightBound); // Aplica os limites corretamente
        
        transform.position = pos;
    }

    // Método para resetar a posição da raquete
    public void ResetPaddle()
    {
        transform.position = new Vector2(-8, -16); // Reseta para o centro
    }
}
