using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isJumping = false;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on Player object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        jump();
    }

    void jump()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Z))
        {
            isJumping = true;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump") == false)
            {
                animator.Play("Jump",-1,0);
            }
        }
        isJumping = false;
    }
}
