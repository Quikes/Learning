using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {


    private float minimum;
    private float maximum;
    public CharacterController controller;
	// Use this for initialization
	void Start () {
        minimum = 1.2f;
        maximum = 1.8f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.C) && controller.height>1.2f){
            controller.height -= 5f * Time.deltaTime;
        }
        else if(controller.height<1.8f && !Input.GetKey(KeyCode.C))
        {
            controller.height += 5f * Time.deltaTime;
            gameObject.transform.position += new Vector3(0, 0.3f,0);

        }
        


    }
    
}
