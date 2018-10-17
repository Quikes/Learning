using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public float Health = 100;
    private EnemyAI thisEnemyAI;


    

    public void Die()
    {
        Destroy(gameObject);
    }




    public void ApplyDamage(float meleeDamage)

    {
        
        Health -= meleeDamage;
        if (Health <= 100)
        {

            thisEnemyAI = gameObject.GetComponent<EnemyAI>();
            thisEnemyAI.chaseRange += 15;
            thisEnemyAI.moveSpeed += 2;
            thisEnemyAI.lookAtDistance += 40;
        }
        if (Health <= 0)
        {
            Die();
        }


    }
}
