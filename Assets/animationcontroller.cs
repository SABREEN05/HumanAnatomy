using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationcontroller : MonoBehaviour
{
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void onbuttonclickstart()
    {
        ani.SetBool("Blast", true);
    }
    public void onbuttonclickstop()
    {
        ani.SetBool("Blast", false);
    }
}
