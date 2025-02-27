using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
    private Rigidbody2D rb2d; // Define o corpo rígido 2D que representa a bola

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(0, +15));
        }
        else
        {
            rb2d.AddForce(new Vector2(0, -15));
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
    }

    void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);

        SoundManager.instance.PlayGoalSound();
    }

    void Update()
    {
    }
}
