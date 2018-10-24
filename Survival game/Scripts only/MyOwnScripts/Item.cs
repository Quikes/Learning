using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    private WeaponSystem weaponSystem;
    private GameObject player;
    
    public GameObject weaponToAdd;

    private void Start()
    {
        weaponSystem = FindObjectOfType<WeaponSystem>();
        
    }

    public void Interact()
    {
        weaponSystem.PickUp(weaponToAdd);
        
        Destroy(gameObject);

    }
}
