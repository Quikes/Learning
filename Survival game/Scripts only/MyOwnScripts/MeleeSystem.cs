using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSystem : MonoBehaviour
{
    public Animator anim;
    public GameObject[] Weapons;
    public GameObject bloodeffect;
    private GameObject projectile;
    private GameObject arrow;

    private int j;
    private int i;

    public GameObject activeWeapon;
    public GameObject Player;
    public GameObject CameraLocation;
    
    
    

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
        projectile = null;

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
        Ray ray = CameraLocation.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));

        if (Weapons[i].GetComponent<Weapon>().type == "melee")
        {
            if (Physics.Raycast(Player.transform.position, Player.transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;

                if (distance < meleeRange)
                {
                    hit.transform.SendMessage(("ApplyDamage"), meleeDamage, SendMessageOptions.DontRequireReceiver);
                    Instantiate(bloodeffect, hit.point, Quaternion.LookRotation(hit.normal)); 
                }

            }
        }
        else if (Weapons[i].GetComponent<Weapon>().type == "hitscan")
        {

            if (Physics.Raycast(ray, out hit))
                distance = hit.distance;

            
            {
                Debug.DrawLine(ray.origin, hit.point,Color.red,5000000000f,false);
                hit.transform.SendMessage(("ApplyDamage"), meleeDamage, SendMessageOptions.DontRequireReceiver);
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Enemy")
                {
                    Instantiate(bloodeffect, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }else if(Weapons[i].GetComponent<Weapon>().type == "ranged")
        {
            projectile = Weapons[i].GetComponent<Weapon>().projectile;
            arrow = (GameObject)Instantiate(projectile, Weapons[i].transform.position, CameraLocation.transform.rotation );
            arrow.GetComponent<Rigidbody>().velocity = CameraLocation.transform.TransformDirection(new Vector3(0, 0, Weapons[i].GetComponent<Weapon>().projectileSpeed));
            


            Destroy(arrow,3f);


        }
    }
}

