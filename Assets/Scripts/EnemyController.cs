using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        if (transform.position.y < -6f) // Adjust based on your game view
        {
            Destroy(gameObject);
        }
    }
}
