
using UnityEngine;

public class BladeAnimation : MonoBehaviour {
    public Animator anim;
    int attackHash = Animator.StringToHash("Attack");
    int attackIdle = Animator.StringToHash("IdleBlade");
    float wait = 2f;

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
