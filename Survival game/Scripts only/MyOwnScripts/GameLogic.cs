using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {

    public bool playerDead = false;
    
    public  Camera cam2;
    public GameObject newPlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
            GUI.Box(new Rect(0, 0, 200, 100), "Welcome to my game!\nWSAD to run, Space to jump\nQ to swap weapons\n 1st and 2nd are swords \n3rd is a hitscan gun \n 4th is a ..bow? \n Enjoy!");
        }
    }

        
}
