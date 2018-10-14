
using UnityEngine;

public class EnemyAI : MonoBehaviour {


    public float distance;
    public Transform target;
    public float lookAtDistance = 25.0f;
    public float attackRange = 15.0f;
    public float moveSpeed = 5.0f;
    public float damping = 6.0f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(target.position, transform.position);

        if (distance < lookAtDistance)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            LookAt();

        }
        if (distance > lookAtDistance)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (distance < attackRange)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Attack();
        }
		
	}

    public void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);  //slerp Slowly turns, damping smooths it out.
    }


    public void Attack()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}


