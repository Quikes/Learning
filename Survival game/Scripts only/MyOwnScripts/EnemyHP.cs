using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public float Health = 100;


    private void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }




    public void ApplyDamage(float meleeDamage)
    {
        Health -= meleeDamage;


    }
}
