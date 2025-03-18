using UnityEngine;

public class BallControll : MonoBehaviour
{
    private Rigidbody2D rb2d; // Define o corpo rígido 2D que representa a bola

    void GoBall()
    {
        // Aplica uma força aleatória para a bola
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(0, +15)); // Movimento para cima
        }
        else
        {
            rb2d.AddForce(new Vector2(0, -15)); // Movimento para baixo
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 1); // Chama a função GoBall após 1 segundo
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = rb2d.linearVelocity.y + (coll.collider.attachedRigidbody.linearVelocity.y * 3);
            rb2d.linearVelocity = vel;

            SoundManager.instance.PlayPaddleSound();
        }
        else if (coll.collider.CompareTag("Wall"))
        {
            SoundManager.instance.PlayWallSound();
        }
        else if (coll.collider.CompareTag("BottomWall"))
        {
            // Decrementa a vida do jogador
            GameManager.playerLives--;
            ResetBall(); // Reseta a bola
            GameObject playerPaddle = GameObject.FindWithTag("Player"); // Encontra a raquete do jogador
            if (playerPaddle != null)
            {
                playerPaddle.GetComponent<PlayerControls>().ResetPaddle(); // Reseta a raquete
            }
        }
    }

    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero; // Zera a velocidade da bola
        transform.position = new Vector2(-8, -14); // Define a posição inicial da bola
        Invoke("GoBall", 1); // Chama o movimento da bola após 1 segundo
    }

    void RestartGame()
    {
        ResetBall();
    }

    void Update()
    {
    }
}
