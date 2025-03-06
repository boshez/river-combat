using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public bool hasShield = false;

    private float nextFireTime;
    private bool isRapidFire = false;

    void Update()
    {
        Move();
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + (isRapidFire ? fireRate / 2 : fireRate);
        }
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Clamp position to screen bounds
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2.5f, 2.5f);
        pos.y = Mathf.Clamp(pos.y, -4.5f, 4.5f);
        transform.position = pos;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    public IEnumerator ApplySpeedBoost(float duration)
    {
        float originalSpeed = moveSpeed;
        moveSpeed *= 1.5f;
        yield return new WaitForSeconds(duration);
        moveSpeed = originalSpeed;
    }

    public IEnumerator ApplyRapidFire(float duration)
    {
        isRapidFire = true;
        yield return new WaitForSeconds(duration);
        isRapidFire = false;
    }

    public IEnumerator ApplyShield(float duration)
    {
        hasShield = true;
        yield return new WaitForSeconds(duration);
        hasShield = false;
    }
}
