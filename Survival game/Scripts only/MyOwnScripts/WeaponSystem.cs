using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public Animator anim;
    //public GameObject[] allWeapons;
    public GameObject bloodeffect;
    private GameObject projectile;
    private GameObject arrow;
    public float interactRange = 10f;

    

    public GameObject weaponNew;

    
    public int i;

    public GameObject activeWeapon;
    public GameObject Player;
    public GameObject CameraLocation;


   

    [SerializeField]
    List<GameObject> itemList;


    [SerializeField]
    List<GameObject> myInventory;

    [SerializeField]
    public List<GameObject> allWeapons;
    
    
    
    public float distance;
    public int meleeDamage;
    public float meleeRange;

    private void Awake()
    {
        
    }

    private void Start()
    {

        
        //Debug.Log(allWeapons[3]);

        i = 0;
        //activeWeapon = allWeapons[0];
        //meleeDamage = allWeapons[i].GetComponent<Weapon>().meleeDamage;
        //meleeRange = allWeapons[i].GetComponent<Weapon>().meleeRange;
        //projectile = null;


    }

    private void Update()


    {
        

        if (Input.GetKeyDown("q"))
        {
            
            SwapWeapon();
            meleeDamage = allWeapons[i].GetComponent<Weapon>().meleeDamage;
            meleeRange = allWeapons[i].GetComponent<Weapon>().meleeRange;
            
        }
        if (Input.GetKeyDown("e"))
        {
            Interact();
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

    public void PickUp(GameObject itemToAdd)
    {
        for (int i = 0; i < allWeapons.Count; i++)
        {
            if (allWeapons[i] == null)
            {
                allWeapons[i] = itemToAdd;
                return;
            }
        }
    }
    public void ThrowAway(int itemToThrow)
    {
        Debug.Log("throwing away " + allWeapons[itemToThrow].GetComponent<Weapon>().Namy);
        allWeapons[itemToThrow] = null;
        
    }
   
    public void SetWeapon(int number)
    {
        Debug.Log("Setting Weapon");
        //allWeapons[i].SetActive(false);
        Destroy(weaponNew);

        weaponNew = Instantiate(allWeapons[number], gameObject.transform);
        
        weaponNew.SetActive(true);
        anim = allWeapons[number].GetComponent<Animator>();
        activeWeapon = weaponNew;
        i = number;
        

    }
    public void SwapWeapon()
    {
        // Debug.Log("SwappingWeapon");

        
        
        Debug.Log("setting to inactive");
       

        if (i == allWeapons.Count - 1 || allWeapons[i+1]==null)
        {
            allWeapons[i].SetActive(false);
            Destroy(weaponNew);

            i = 0;
            weaponNew = Instantiate(allWeapons[i], gameObject.transform);
            weaponNew.SetActive(true);
            anim = weaponNew.GetComponent<Animator>();
            activeWeapon = weaponNew;
            

        }
        else
        {
            allWeapons[i].SetActive(false);
            Destroy(weaponNew);
            i++;
            weaponNew = Instantiate(allWeapons[i], gameObject.transform);
            weaponNew.SetActive(true);
            anim = weaponNew.GetComponent<Animator>();
            activeWeapon = weaponNew;

        }


    }
    public void Attack()
    {
        RaycastHit hit;
        Ray ray = CameraLocation.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));

        /*if (Weapons[i].GetComponent<Weapon>().type == "melee")
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
    }*/
        if (allWeapons[i].GetComponent<Weapon>().type == "hitscan" || allWeapons[i].GetComponent<Weapon>().type == "melee" )
        {


            if (Physics.Raycast(ray, out hit))

            {
                distance = hit.distance;
                Debug.DrawLine(ray.origin, hit.point, Color.red, 5000000000f, false);
                if (distance < meleeRange)
                {
                    hit.transform.SendMessage(("ApplyDamage"), meleeDamage, SendMessageOptions.DontRequireReceiver);
                    Debug.Log(hit.collider.tag);
                    if (hit.collider.tag == "Enemy")
                    {
                        Instantiate(bloodeffect, hit.point, Quaternion.LookRotation(hit.normal));
                    }
                }
            }
        }else if(allWeapons[i].GetComponent<Weapon>().type == "ranged")
        {
            projectile = allWeapons[i].GetComponent<Weapon>().projectile;
            arrow = (GameObject)Instantiate(projectile, weaponNew.transform.position, CameraLocation.transform.rotation );
            arrow.GetComponent<Rigidbody>().velocity = CameraLocation.transform.TransformDirection(new Vector3(0, 0, allWeapons[i].GetComponent<Weapon>().projectileSpeed));
            


            Destroy(arrow,3f);


        }
    }
    public void Interact()
    {
        RaycastHit hit;
        Ray ray = CameraLocation.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0));
        if (Physics.Raycast(ray, out hit))

        {
            distance = hit.distance;
            Debug.DrawLine(ray.origin, hit.point, Color.red, 5000000000f, false);
            if (distance < interactRange)
            {
                hit.transform.SendMessage(("Interact"), SendMessageOptions.DontRequireReceiver);
                Debug.Log("interacting send");
                Debug.Log(hit.collider.tag);


            }
        }

    }
}

