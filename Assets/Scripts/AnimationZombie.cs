using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationZombie : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        // anim.SetFloat("walking", 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject colObject = other.gameObject;

        if (colObject.tag == "Player")
        {
            // anim.SetBool("hurt", true);
            //anim.SetBool("walking", true);
            //anim.Play("Z_FallingBack");
        }
    }
}


