using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;  // Pontuação do player
    public static int playerLives = 3;  // Vidas do jogador
    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola

    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
        Time.timeScale = 1; // Garante que o jogo inicie normalmente
    }

    public static void Score(string wallID)
    {
        if (wallID == "RightWall")
        {
            PlayerScore += 100; // Cada bloco vale 100 pontos
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Score: " + PlayerScore);
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 50, 100, 100), "Lives: " + playerLives);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            RestartGame();
        }

        if (playerLives <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "GAME OVER");
            Time.timeScale = 0; // Pausa o jogo
        }

        if (PlayerScore == 4200)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }

    void RestartGame()
    {
        PlayerScore = 0;
        playerLives = 3;
        Time.timeScale = 1; // Garante que o jogo volte ao normal

        // Reseta a bola
        theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);

        // Reseta a raquete do jogador
        GameObject playerPaddle = GameObject.FindWithTag("Player");
        if (playerPaddle != null)
        {
            playerPaddle.GetComponent<PlayerControls>().ResetPaddle();
        }

        // Recarrega a cena para resetar todos os blocos e o estado inicial
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
