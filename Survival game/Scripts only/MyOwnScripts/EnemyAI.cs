using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAI : MonoBehaviour
{


    public float distance;
    public GameObject player = null;
    public float lookAtDistance = 25.0f;
    public float chaseRange = 15.0f;
    public float attackRange = 1.5f;
    public float moveSpeed = 5.0f;
    public float damping = 6.0f;
    public float attackSpeed = 1f;
    public float damage = 10f;
    public Transform target;

    public float attackDelay;
    

    public CharacterController controller;
    public float gravity = 1f;
    private Vector3 moveDirection = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        attackDelay = Time.time;
        
        
    }

    // Update is called once per frame
    void Update()
    {


        attackDelay -= Time.deltaTime;
        if (target != null)
        {
            distance = Vector3.Distance(target.position, transform.position);
            


            if (distance < lookAtDistance)
            {

                LookAt();

            }
            if (distance > lookAtDistance)
            {
                GetComponent<Renderer>().material.color = Color.green;
            }
            if (distance < attackRange)
            {
                Attack();
            }
            else if (distance < chaseRange)
            {
                Chase();
            }
            

        }else if(player == null)
        {
            SearchForPlayer();
        }

    }

    public void LookAt()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);  //slerp Slowly turns, damping smooths it out.
    }


    public void Chase()
    {
        moveDirection = transform.forward;
        moveDirection *= moveSpeed;

        moveDirection += Vector3.up * -gravity;
        controller.Move(moveDirection * Time.deltaTime);

        GetComponent<Renderer>().material.color = Color.red;
       
    }

    public void Attack()
    {
        

        if (attackDelay <=0)
        {
            Debug.Log("Attacked");
            target.SendMessage("ApplyDamage",damage, SendMessageOptions.DontRequireReceiver);
            
            attackDelay = attackSpeed;
        }
        

    }

    
    public void SearchForPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player!= null){


            target = player.transform;
        }
    }
    
}


