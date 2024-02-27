using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOUCH_OBJECT : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        if(Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                hit.collider.GetComponent<ButtonScript>().OnButtonClick();
            }
        }

        
    }
}
