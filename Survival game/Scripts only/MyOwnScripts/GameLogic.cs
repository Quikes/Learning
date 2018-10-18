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
    public GameObject[] buttonsgame;
    public Button[] buttons;
    
    
    public MeleeSystem meleeSystem;
    public GameObject player;
    





    // Use this for initialization
    void Start () {
        inventory.SetActive(true);
        meleeSystem = FindObjectOfType<MeleeSystem>();
        buttonsgame = GameObject.FindGameObjectsWithTag("Button");
        Debug.Log(buttonsgame.Length);



        buttons = new Button[buttonsgame.Length];

        for (int i = buttons.Length -1; i >= 0; i--)
        {
            int indexer = i;
            buttons[i] = buttonsgame[i].GetComponent<Button>();
            //buttons[i].GetComponent<Text>().text = "hehe"; ///meleeSystem.Weapons[indexer].GetComponent<Weapon>().Namy;
            buttons[i].onClick.AddListener(() => click(indexer));

            

            
        }
        

        

        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        inventory.SetActive(false);

    }
    public void Awake()
    {
        
    }


    public void click(int i)
    {
        
        Debug.Log("hello " +i);
        meleeSystem.SetWeapon(i);
        


    }
	
	// Update is called once per frame
	void Update () {
       
            

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
            if (inventory.activeSelf)
            {
                meleeSystem.enabled = false;
                player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                
            }
            else
            {
                meleeSystem.enabled = true;
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
