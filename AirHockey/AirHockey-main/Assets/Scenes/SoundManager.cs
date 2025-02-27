using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance; // Criando uma instância para fácil acesso

    public AudioClip goalSound;    // Som quando um gol é feito
    public AudioClip wallSound;    // Som quando a bola bate na parede
    public AudioClip paddleSound;  // Som quando a bola bate na raquete

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

    // Funções para tocar os sons
    public void PlayGoalSound()
    {
        audioSource.PlayOneShot(goalSound);
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
