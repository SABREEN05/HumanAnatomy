using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
 public void PlayAnimation()
    {
        GetComponent<Animator>().SetTrigger("Play");
    }
}
