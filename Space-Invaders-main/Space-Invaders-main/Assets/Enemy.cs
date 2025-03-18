using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isActive = true;

    void Start()
    {
        SaveInitialPosition();
    }

    public void SaveInitialPosition()
    {
        initialPosition = transform.position;
    }

    public void Respawn()
    {
        transform.position = initialPosition;
        gameObject.SetActive(true); // Ativa o inimigo se ele foi desativado
    }

    void OnDisable()
    {
        isActive = false;
    }
}
