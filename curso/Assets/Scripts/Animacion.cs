using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");

        anim.SetInteger("Speed", (int)X);

    }

    public void AnimationEvent()
    {
        Debug.Log("CORRIO");
    }
}
