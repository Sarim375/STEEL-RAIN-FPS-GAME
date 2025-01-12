using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public void GetDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
