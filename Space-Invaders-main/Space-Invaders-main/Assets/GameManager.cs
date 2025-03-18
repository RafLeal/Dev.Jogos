using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore = 0;

    public static void AddScore(int points)
    {
        PlayerScore += points;
    }

    // Função para exibir a pontuação na UI
    void OnGUI()
    {
        // Configuração inicial do skin
        GUIStyle scoreStyle = new GUIStyle();
        scoreStyle.fontSize = 48;
        scoreStyle.normal.textColor = Color.white;
        scoreStyle.alignment = TextAnchor.MiddleCenter; // Centraliza o texto

        // Adiciona sombreamento para melhorar a visibilidade
        GUIStyle shadowStyle = new GUIStyle(scoreStyle);
        shadowStyle.normal.textColor = new Color(0, 0, 0, 0.75f); // Sombra preta semi-transparente

        // Posição do texto e dimensões
        Rect scoreRect = new Rect(Screen.width / 2 + 200, 50, 200, 100);

        // Primeiro desenha a sombra (ligeiramente deslocada)
        GUI.Label(new Rect(scoreRect.x + 2, scoreRect.y + 2, scoreRect.width, scoreRect.height), 
                "SCORE: " + PlayerScore, shadowStyle);

        // Depois desenha o texto principal
        GUI.Label(scoreRect, "SCORE: " + PlayerScore, scoreStyle);
    }
}