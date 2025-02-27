using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10.0f; // Velocidade da raquete
    public float boundX = 6.5f; // Limite nas laterais do campo
    public float boundY = 4.0f; // Limite superior e inferior
    public bool isUpperPlayer;  // Define se a raquete pertence ao jogador superior ou inferior

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = Mathf.Clamp(mousePos.x, -boundX, boundX); // Limita X

        // Define o limite Y baseado na metade da quadra
        if (isUpperPlayer)
        {
            pos.y = Mathf.Clamp(mousePos.y, 0, boundY); // Raquete superior não desce do meio
        }
        else
        {
            pos.y = Mathf.Clamp(mousePos.y, -boundY, 0); // Raquete inferior não sobe do meio
        }

        transform.position = pos;
    }
}


