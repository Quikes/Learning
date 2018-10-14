using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    private string theCollider;
       public void OnTriggerEnter(Collider other)
    {

        theCollider = other.tag;

        if (theCollider == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        theCollider = other.tag;

        if (theCollider == "Player")
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().loop = false;
        }
    }
}
