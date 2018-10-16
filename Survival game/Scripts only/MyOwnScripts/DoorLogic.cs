
using UnityEngine;

public class DoorLogic : MonoBehaviour {

    private bool drawGUI = false;
    public GameObject door;
    private Animator anim;
    private bool doorOpen;
    private string doorstate;
    
	// Use this for initialization
	void Start () {

        
        anim = door.GetComponentInParent<Animator>();
        anim.SetBool("DoorOpen", false);
        doorOpen = false;
        doorstate = "close";

    }
	
	// Update is called once per frame
	void Update () {

        if(drawGUI==true && Input.GetKeyDown(KeyCode.E))
        {
            ChangeDoorState();
            if (doorOpen)
            {
                doorstate = "open";

            }
            else
            {
                doorstate = "close";
            }
            
        }


		
	}

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")

        {
            
            Debug.Log("Works");
            drawGUI = true;
        }
        

        
    }
    public void OnTriggerExit(Collider collider)
    {
        drawGUI = false;
        
    }
    public void OnGUI()
    {
        if (drawGUI == true)
        {

        GUI.Box(new Rect(Screen.width*0.5f-75,Screen.height*0.2f-11,150,22), "Press 'E' to "+ doorstate);
        }

    }
    public void ChangeDoorState()
    {
        doorOpen = !doorOpen;
        anim.SetBool("DoorOpen", doorOpen);
        

    }
}
