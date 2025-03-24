using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Array de asteroides
    public float[] spawnRates; // Taxas de spawn para cada tipo de asteroide
    public float spawnX = -10f; // Posição X fixa (parede esquerda)
    public float minY = -5f, maxY = 5f; // Define a altura do spawn

    private float[] nextSpawnTimes; // Array para controlar o tempo de spawn de cada asteroide

    void Start()
    {
        nextSpawnTimes = new float[asteroidPrefabs.Length]; // Inicializa o array de tempos de spawn

        // Inicializa os tempos de spawn
        for (int i = 0; i < asteroidPrefabs.Length; i++)
        {
            nextSpawnTimes[i] = Time.time + Random.Range(0f, spawnRates[i]); // Spawna com um intervalo aleatório
        }
    }

    void Update()
    {
        for (int i = 0; i < asteroidPrefabs.Length; i++)
        {
            // Verifica se é hora de spawnar o asteroide i
            if (Time.time >= nextSpawnTimes[i])
            {
                SpawnAsteroid(i); // Spawn do asteroide
                nextSpawnTimes[i] = Time.time + spawnRates[i]; // Atualiza o tempo de spawn para o próximo
            }
        }
    }

    void SpawnAsteroid(int index)
    {
        float spawnY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        GameObject asteroid = Instantiate(asteroidPrefabs[index], spawnPosition, Quaternion.identity);
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(Mathf.Abs(3f), 0f); // Define a velocidade do asteroide
            rb.angularVelocity = 0f; // Impede rotação
        }

        asteroid.transform.rotation = Quaternion.identity; // Impede rotação ao spawn
    }
}
