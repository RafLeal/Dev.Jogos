using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // Criando uma instância para fácil acesso

    public AudioClip blockBreakSound; // Som quando um bloco é destruído
    public AudioClip wallSound;       // Som quando a bola bate na parede
    public AudioClip paddleSound;     // Som quando a bola bate na raquete

    private AudioSource audioSource;

    void Awake()
    {
        // Garante que apenas um SoundManager exista na cena
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Função para tocar o som quando um bloco for quebrado
    public void PlayBlockBreakSound()
    {
        audioSource.PlayOneShot(blockBreakSound);
    }

    public void PlayWallSound()
    {
        audioSource.PlayOneShot(wallSound);
    }

    public void PlayPaddleSound()
    {
        audioSource.PlayOneShot(paddleSound);
    }
}
