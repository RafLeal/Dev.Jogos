using UnityEngine;

public class Block : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Quando a bola colide com o bloco
        if (collision.CompareTag("Ball"))
        {
            // Pega a referência ao Rigidbody2D da bola
            Rigidbody2D ballRb = collision.GetComponent<Rigidbody2D>();

            if (ballRb != null)
            {
                // Inverte a direção do movimento para simular o rebote
                ballRb.linearVelocity = new Vector2(ballRb.linearVelocity.x, -ballRb.linearVelocity.y);
            }

            // Notifica o GameManager sobre o ponto
            GameManager.PlayerScore += 100;

            // Toca o som de destruição do bloco
            SoundManager.instance.PlayBlockBreakSound();

            // Desativa o bloco ao ser destruído
            gameObject.SetActive(false);
        }
    }
}
