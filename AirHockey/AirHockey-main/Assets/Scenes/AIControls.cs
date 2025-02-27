using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour
{
    public Transform ball;  // Referência à bola
    public float speed = 5.0f;  // Velocidade da IA
    public float boundX = 6.5f; // Limite lateral do campo
    public float boundY = 4.0f; // Limite superior
    public float reactionTime = 0.1f; // Tempo de reação da IA

    private Vector3 targetPosition;

    void Update()
    {
        if (ball != null)
        {
            // A IA segue a posição da bola no eixo Y
            targetPosition = new Vector3(ball.position.x, ball.position.y, transform.position.z);

            // Limita o movimento no eixo X dentro dos limites laterais
            targetPosition.x = Mathf.Clamp(targetPosition.x, -boundX, boundX);

            // A IA só pode se mover na parte superior do campo
            targetPosition.y = Mathf.Clamp(targetPosition.y, 0, boundY);

            // Move suavemente em direção ao alvo
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
}
