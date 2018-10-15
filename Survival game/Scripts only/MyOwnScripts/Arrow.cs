
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float meleeDamage = 50f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHP>().ApplyDamage(meleeDamage);
            Destroy(gameObject);
        } 

    }
}
