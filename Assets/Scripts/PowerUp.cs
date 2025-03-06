using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        ExtraSpeed,
        RapidFire,
        Shield
    }

    public PowerUpType type;
    public float duration = 5f;
    public float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyPowerUp(other.gameObject);
            Destroy(gameObject);
        }
    }

    void ApplyPowerUp(GameObject player)
    {
        PlayerController controller = player.GetComponent<PlayerController>();
        if (controller != null)
        {
            switch (type)
            {
                case PowerUpType.ExtraSpeed:
                    StartCoroutine(controller.ApplySpeedBoost(duration));
                    break;
                case PowerUpType.RapidFire:
                    StartCoroutine(controller.ApplyRapidFire(duration));
                    break;
                case PowerUpType.Shield:
                    StartCoroutine(controller.ApplyShield(duration));
                    break;
            }
        }
    }
}
