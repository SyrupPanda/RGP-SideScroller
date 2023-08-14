using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBullet : MonoBehaviour
{

    public GameObject projectile;
    private const float radius = 5.0f;
    public float speed;
    public int bulletAmount;
    public float bulletRate;

    private float fireTimer = 0;
    private void SpawnProjectile(int magazine, Vector2 ports)
    {
        float angleStep = 360f / magazine;
        float angle = 0f;

        for (int i = 0; i <= magazine - 1; i++)
        {
            float projectileDirXPosition = ports.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = ports.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            float tester = projectileDirYPosition - ports.y;

            if (tester < 0)
            {
                projectileDirYPosition += 1;
            }

            Vector2 projectileVector = new Vector2(projectileDirXPosition, projectileDirYPosition);
            Vector2 projectileMoveDirection = (projectileVector - ports).normalized * speed;

            GameObject bullet = Instantiate(projectile, ports, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = projectileMoveDirection;

            angle += angleStep;
        }
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > bulletRate)
        {
            SpawnProjectile(bulletAmount, this.gameObject.transform.position);
            fireTimer = 0;
        }
        if (fireTimer < 0)
        {
            fireTimer = 0;
        }

        Debug.Log(fireTimer);
    }
}
