using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ObjectHighlighter : MonoBehaviour
{
    public Material highlightMaterial;
    public TextMeshPro descriptionText;

    private Material originalMaterial;
    private GameObject lastHighlightedObject;

    private void Start()
    {
        // Save the original material of the object
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Raycast to detect the object tapped
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the object has a renderer
                    Renderer renderer = hit.collider.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        // Reset transparency on the previously highlighted object
                        if (lastHighlightedObject != null)
                        {
                            lastHighlightedObject.GetComponent<Renderer>().material = originalMaterial;
                        }

                        // Highlight the new object
                        renderer.material = highlightMaterial;

                        // Update the last highlighted object
                        lastHighlightedObject = hit.collider.gameObject;

                        // Display description UI
                        DisplayDescription(hit.collider.gameObject);
                    }
                }
            }
        }
    }

    private void DisplayDescription(GameObject highlightedObject)
    {
        // Update UI content with the description of the highlighted object
        descriptionText.text = "Object Description";
    }
}
