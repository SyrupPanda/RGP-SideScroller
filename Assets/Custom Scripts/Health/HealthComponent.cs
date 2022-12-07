using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public float hitPoints;
    public Image Health;
    public bool hasHealthBar;

    void update()
    {
        if (hasHealthBar)
        {
            Health.fillAmount = hitPoints / 100;
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Destroy (gameObject);
        }
    }
}
