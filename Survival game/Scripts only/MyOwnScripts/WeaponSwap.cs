using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class WeaponSwap : MonoBehaviour {

    public GameObject[] Weapons;
    public MeleeSystem melee;
    private int j;
    private int i;
    public GameObject activeWeapon;

    public void Start()
    {
        j = Weapons.Length;
        i = 0;
        activeWeapon = Weapons[0];
    }

    public void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            
            SwapWeapon();
            activeWeapon = Weapons[i];
        }

     


    }
    public void SwapWeapon()
    {

        
        if (Weapons[i].activeInHierarchy)
        {
            Weapons[i].SetActive(false);
            if (i == Weapons.Length-1)
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
}
