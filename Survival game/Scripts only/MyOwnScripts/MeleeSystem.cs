using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Weapons;

    private int j;
    private int i;

    public GameObject activeWeapon;
    public GameObject Player;
    

    public float distance;
    public int meleeDamage;
    public float meleeRange;


    private void Start()
    {
        j = Weapons.Length;
        i = 0;
        activeWeapon = Weapons[0];
        meleeDamage = Weapons[i].GetComponent<Weapon>().meleeDamage;
        meleeRange = Weapons[i].GetComponent<Weapon>().meleeRange;

    }

    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            
            SwapWeapon();
            activeWeapon = Weapons[i];
            meleeDamage = Weapons[i].GetComponent<Weapon>().meleeDamage;
            meleeRange = Weapons[i].GetComponent<Weapon>().meleeRange;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            
            
            anim.SetTrigger("Attack");

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("isRunning", false);
        }
        

    }

    public void SwapWeapon()
    {


        if (Weapons[i].activeInHierarchy)
        {
            Weapons[i].SetActive(false);
            if (i == Weapons.Length - 1)
            {
                i = 0;
                Weapons[i].SetActive(true);
                
            }
            else
            {
               
                Weapons[i + 1].SetActive(true);
                i++;
            }

        }

    }
    public void Attack()
    {
        RaycastHit hit;


        if (Physics.Raycast(Player.transform.position, Player.transform.TransformDirection(Vector3.forward), out hit))
        {
            distance = hit.distance;

            if (distance < meleeRange)
            {
                hit.transform.SendMessage(("ApplyDamage"), meleeDamage, SendMessageOptions.DontRequireReceiver);

            }

        }
    }

}

