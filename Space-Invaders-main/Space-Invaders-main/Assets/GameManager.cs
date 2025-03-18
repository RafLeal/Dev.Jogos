using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static int PlayerLives = 3;
    public static bool IsGameOver = false;

    public Sprite lifeSprite; // 🔹 Ícone das vidas (defina no Inspector)
    public Font scoreFont;    // 🔹 Fonte personalizada (defina no Inspector)
    public Font gameOverFont; // 🔹 Fonte personalizada para o Game Over (defina no Inspector)
    public Font buttonFont;   // 🔹 Fonte personalizada para o texto do botão (defina no Inspector)

    private const int ScoreThreshold = 15300; // 🔹 Pontuação base para reiniciar os inimigos

    private GUIStyle spriteStyle;

    void Start()
    {
        spriteStyle = new GUIStyle();
    }

    void Update()
    {
        // 🔹 Se o Score for múltiplo de 15.300 e maior que 0, verifica a tecla R
        if (PlayerScore > 0 && PlayerScore % ScoreThreshold == 0)
        {
            // 🔹 Se a tecla R for pressionada, reinicia os inimigos
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartEnemies();
            }
        }

        // 🔹 Verifica se o jogador perdeu todas as vidas
        if (PlayerLives <= 0 && !IsGameOver)
        {
            SetGameOver();
        }
    }

    public static void AddScore(int points)
    {
        PlayerScore += points;
    }

    public static void LoseLife()
    {
        if (PlayerLives > 0)
        {
            PlayerLives--;
            if (PlayerLives <= 0)
            {
                SetGameOver();
            }
        }
    }

    public static void GainLife()
    {
        if (PlayerLives < 3)
        {
            PlayerLives++;
        }
    }

    public static void SetGameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0; // Pausa o jogo
        Debug.Log("Game Over!");
    }

    public static void RestartGame()
    {
        // Reinicia todos os valores
        PlayerScore = 0;
        PlayerLives = 3;
        IsGameOver = false;

        // Reinicia a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Retorna o tempo para o normal após o reinício
        Time.timeScale = 1;
    }

    void OnGUI()
    {
        // 🔹 Estilo do Score
        GUIStyle scoreStyle = new GUIStyle();
        scoreStyle.fontSize = 40;
        scoreStyle.normal.textColor = Color.white;
        scoreStyle.alignment = TextAnchor.MiddleCenter;

        // 🔹 Se a fonte personalizada estiver definida, usa ela
        if (scoreFont != null)
        {
            scoreStyle.font = scoreFont;
        }

        // 🔹 Criando a sombra para melhor visibilidade
        GUIStyle shadowStyle = new GUIStyle(scoreStyle);
        shadowStyle.normal.textColor = new Color(0, 0, 0, 0.75f);

        // 🔹 Posição do Score
        Rect scoreRect = new Rect(Screen.width / 2 + 300, 450, 200, 100);

        // 🔹 Desenha sombra primeiro
        GUI.Label(new Rect(scoreRect.x + 2, scoreRect.y + 2, scoreRect.width, scoreRect.height), 
                "SCORE: " + PlayerScore, shadowStyle);

        // 🔹 Desenha o Score principal
        GUI.Label(scoreRect, "SCORE: " + PlayerScore, scoreStyle);

        // 🔹 Desenha as vidas com sprites
        DrawPlayerLives();

        // 🔹 Se o jogo estiver finalizado, exibe a tela de Game Over com o botão de reiniciar
        if (IsGameOver)
        {
            // 🔹 Estilo para o texto "Game Over"
            GUIStyle gameOverStyle = new GUIStyle();
            gameOverStyle.fontSize = 60;
            gameOverStyle.normal.textColor = Color.red;
            gameOverStyle.alignment = TextAnchor.MiddleCenter;

            // 🔹 Usa a fonte personalizada para "Game Over", se definida
            if (gameOverFont != null)
            {
                gameOverStyle.font = gameOverFont;
            }

            // 🔹 Exibe a mensagem de Game Over no centro da tela
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 400, 100), "GAME OVER", gameOverStyle);

            // 🔹 Estilo para o texto do botão
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 30;
            buttonStyle.normal.textColor = Color.white;

            // 🔹 Usa a fonte personalizada para o botão, se definida
            if (buttonFont != null)
            {
                buttonStyle.font = buttonFont;
            }

            // 🔹 Exibe o botão de reiniciar
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 50, 200, 50), "Reiniciar Jogo", buttonStyle))
            {
                RestartGame();
            }
        }
    }

    private void DrawPlayerLives()
    {
        if (lifeSprite == null)
        {
            Debug.LogError("Life sprite is not assigned!");
            return;
        }

        float lifeX = 20;
        float lifeY = 500;
        float lifeSpacing = 10;
        float spriteSize = 30; // 🔹 Ajuste o tamanho do sprite aqui

        for (int i = 0; i < PlayerLives; i++)
        {
            Rect spriteRect = new Rect(lifeX + (lifeSpacing + spriteSize) * i, lifeY, spriteSize, spriteSize);
            GUI.DrawTexture(spriteRect, lifeSprite.texture, ScaleMode.ScaleToFit);
        }
    }

    private void RestartEnemies()
    {
        // Reinicia a cena e garante que todos os inimigos sejam recarregados corretamente
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Resetar o estado de inimigos (se necessário):
        // Adicione qualquer código adicional aqui para resetar inimigos, pontos ou outras variáveis

        Debug.Log("Inimigos reiniciados!");
    }
}
