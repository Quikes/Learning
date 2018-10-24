
using UnityEngine;

public class Weapon : MonoBehaviour {

    public string Namy = "test";
    public int meleeDamage = 0;
    public int meleeRange = 0;
    public string type = "melee";
    public float projectileSpeed = 0f;
    public GameObject projectile = null;
    public Animator anim;
    public WeaponSystem weaponSystem;
    public GameObject pickupModel;
    

    private void Start()
    {
        weaponSystem = FindObjectOfType<WeaponSystem>();
        anim = GetComponent<Animator>();
        //weaponSystem.Attack();
        
    }
    public void Attack()
    {
        weaponSystem.Attack();
    }
    

}


