using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public bool playerDead = false;
    
    public Camera cam2;
    public GameObject newPlayer;
    public PlayerHP playerHP;
    public GameObject inventory;
    //public GameObject[] buttonsgame;
    public Button[] buttons;

    public Button Equip;
    public Button Delete;
    public Button button;
    
    
    public WeaponSystem weaponSystem;
    public GameObject player;

    public int selectedWeapon;
    




    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {

        //buttons = new Button[24];
        
        UpdateButtonNames();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Startup();


    }

    /*public void SetButtons()
    {

        
        
    
        weaponSystem = FindObjectOfType<WeaponSystem>();
        buttonsgame = GameObject.FindGameObjectsWithTag("Button");
        Debug.Log(buttonsgame.Length);


        Debug.Log(weaponSystem.allWeapons.Count);
        buttons = new Button[buttonsgame.Length];

        for (int i = buttons.Length - 1; i >= 0; i--)
        {
            int indexer = i;
            buttons[indexer] = buttonsgame[indexer].GetComponent<Button>();

            
            if (indexer < weaponSystem.allWeapons.Count)
            {
                Debug.Log("Hi");

                if (weaponSystem.allWeapons[indexer] != null)
                {
                    if (weaponSystem.allWeapons[indexer].GetComponent<Weapon>().Namy != null)
                    {
                        buttons[indexer].GetComponentInChildren<Text>().text = weaponSystem.allWeapons[indexer].GetComponent<Weapon>().Namy;
                    }
                    buttons[indexer].onClick.AddListener(() => Selected(indexer));
                    buttons[indexer].interactable = true;
                }

            }
            else
            {
                buttons[indexer].GetComponentInChildren<Text>().text = "";
                buttons[indexer].interactable = false;

            }
        }
        
        
    }*/
    public void Startup()
    {
        
    }
    public void AccessInventory(int buttonNumber)
    {
        
        Selected(buttonNumber);
        

    }

    public void UpdateButtonNames()
    {
        if(weaponSystem== null)
        {
            weaponSystem = FindObjectOfType<WeaponSystem>();
        }
        
        
        
        for (int i = 0; i < buttons.Length; i++)
        {
            int indexer = i;




            if (weaponSystem.allWeapons[indexer] != null)
            {
                buttons[indexer].GetComponentInChildren<Text>().text = weaponSystem.allWeapons[indexer].GetComponent<Weapon>().Namy;
                buttons[indexer].interactable = true;

            }

            else
            {
                buttons[indexer].GetComponentInChildren<Text>().text = "";
                buttons[indexer].interactable = false;

            }

        }
        

    }
    

   
    public void Selected(int buttonNumber)
    {
        if (weaponSystem.allWeapons[buttonNumber].GetComponent<Weapon>().tag == "Weapon")
        {
            Equip.interactable = true;
        }
        else
        {
            Equip.interactable = false;
        }
        buttons[selectedWeapon].interactable = true;
        selectedWeapon = buttonNumber;
        buttons[buttonNumber].interactable = false;


    }

    public void EquipWeapon()
    {
        
        Debug.Log("hello " + selectedWeapon);
        weaponSystem.SetWeapon(selectedWeapon);
        buttons[selectedWeapon].interactable = true;
        UpdateButtonNames();
        


    }
    public void DeleteWeapon()
    {
        
        buttons[selectedWeapon].interactable = true;
        Instantiate(weaponSystem.allWeapons[selectedWeapon].GetComponent<Weapon>().pickupModel, (player.transform.position + new Vector3 (0,3,0)), Quaternion.identity);
        weaponSystem.allWeapons[selectedWeapon].GetComponent<Weapon>().pickupModel.SetActive(true);
        weaponSystem.ThrowAway(selectedWeapon);
        UpdateButtonNames();
        
        

    }
	
	// Update is called once per frame
	void Update () {

        
            

        if (Input.GetKeyDown(KeyCode.I))
        {
            UpdateButtonNames();

            inventory.SetActive(!inventory.activeSelf);
            if (inventory.activeSelf)
            {
                
                weaponSystem.enabled = false;
                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
            }
            else
            {
                weaponSystem.enabled = true;
                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            
            


        }

        if (playerDead == true)
        {
            cam2.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            
        }
	}
    

    public void Respawn()
    {
        Instantiate(newPlayer, transform);
        playerDead = false;
        
        cam2.enabled = false;
        playerHP = FindObjectOfType<PlayerHP>();
    }


    private void OnGUI()
    {

        if (playerDead == true)
        {
            if (GUI.Button(new Rect(Screen.width * 0.5f - 75, Screen.height * 0.2f - 11, 150, 22), "Respawn"))
            {
                Respawn();
            }
        }
        if (playerDead != true)
        {
            GUI.Box(new Rect(Screen.width * 0.8f, Screen.height * 0.2f, 200, 150), "Welcome to my game!\nWSAD to run, Space to jump\nQ to swap weapons\nPress I for inventory\n1st and 2nd are swords \n3rd is a hitscan gun \n 4th is a ..bow? \n Enjoy!");
            GUI.Box(new Rect(Screen.width * 0.8f, Screen.height * 0.8f, 50, 50), playerHP.Health.ToString());
        }
    }

        
}
