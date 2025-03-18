using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public float autoTransitionTime = 5f; // Tempo antes de iniciar automaticamente

    void Start()
    {
        Invoke("StartGame", autoTransitionTime); // Aguarda o tempo e inicia o jogo automaticamente
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Troca para a cena do jogo
    }
}
