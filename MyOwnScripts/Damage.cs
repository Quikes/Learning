using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Damage : MonoBehaviour {
    public GameObject Player;
    public float distance;
    public int meleeDamage = 50;
    public float meeleRange = 2f;

    public void Attack()
    {
        RaycastHit hit;


        if (Physics.Raycast(Player.transform.position, Player.transform.TransformDirection(Vector3.forward), out hit))
        {
            distance = hit.distance;

            if (distance < meeleRange)
            {
                hit.transform.SendMessage(("ApplyDamage"), meleeDamage, SendMessageOptions.DontRequireReceiver);

            }

        }
    }
}
