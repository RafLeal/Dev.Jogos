using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public Text scoreText;
    public Button startButton;

    void Start()
    {
        // Definir os valores das pontuações na tela
        scoreText.text = "Nave 1 - 100 pontos\n" +
                         "Nave 2 - 300 pontos\n" +
                         "Nave 3 - 500 pontos\n" +
                         "Nave Mãe - 1000 pontos";
        
        // Adicionar ação ao botão
        startButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("SpaceInvaders"); // Substitua "GameScene" pelo nome real da cena do jogo
    }
}
