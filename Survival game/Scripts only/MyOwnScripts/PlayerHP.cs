using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {


    public float Health = 100;
    private GameLogic GameLogic;
    public bool playerDead;
    

    private void Start()
    {
        GameLogic = FindObjectOfType<GameLogic>();

    }


    public void ApplyDamage(float Damage)
    {

        Health -= Damage;
        if (Health <= 0 && playerDead==false)
        {
            Debug.Log("You're Dead!");
            Die();
            
            
        }


    }
    public void Die()
    {
        Destroy(gameObject);

        GameLogic.playerDead = true;
        
        
    }
   
}
