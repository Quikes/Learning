
using UnityEngine;

public class BladeAnimation : MonoBehaviour {
    public Animator anim;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Attacking", false);

    }

    private void Update()
    {
        
        

       

    }

    public void PlayAnimation()
    {

    }
}
