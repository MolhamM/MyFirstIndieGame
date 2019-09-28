using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;
    public static PlayerAnimator instance;
    bool IsPickingUp;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        instance = this;
        IsPickingUp = false;
        SetIdle();
    }

    public void SetWalkingAnimation(){
        animator.SetBool("IsPicking",false);
        animator.SetBool("IsWalking",true);
        IsPickingUp = false;
        loadingbar.instance.stop();
    }
    public void SetIdle(){
        animator.SetBool("IsWalking",false);
        animator.SetBool("IsPicking",false);
        IsPickingUp = true;
    }
    public void SetPickingAnimation(){
        IsPickingUp = true;
        animator.SetBool("IsPicking",true);
    }
    public bool getPickUpStatus(){
        return IsPickingUp;
    }
}
