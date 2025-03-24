using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 200f;

    [Header("Limites da Área de Movimento")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4.5f;
    public float maxY = 4.5f;

    [Header("Configuração do Tiro")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 15f;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Movimento da nave
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;
        transform.position += moveDirection;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Rotação da nave baseada no movimento
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveY, moveX) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        // Disparo com clique do mouse
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = transform.right * projectileSpeed; // Direção baseada na rotação da nave
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o player colidir com um asteroide, o jogo para e chama GameOver
        if (collision.CompareTag("BigAsteroid") || collision.CompareTag("SmallAsteroid"))
        {
            Debug.Log("🚀 O jogador foi atingido! Fim do jogo.");
            GameManager.instance.GameOver();  // Chama o GameOver
            Time.timeScale = 0; // Pausa o jogo
        }
    }
}
