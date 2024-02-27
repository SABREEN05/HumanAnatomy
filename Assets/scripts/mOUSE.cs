using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public GameObject canva;


    private void Start()
    {
        canva.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //MeshRenderer meshRenderer = hit.collider.GetComponent<MeshRenderer>();
                //if (meshRenderer != null && meshRenderer.CompareTag("bone"))
                //{
                //    Debug.Log("hiii");
                //}
                adil adil = hit.collider.GetComponent<adil>();

                if (adil != null && adil.CompareTag("bone") ) {

                    canva.SetActive(true);
                }
            }
        }
    }
}
