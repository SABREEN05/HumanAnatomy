using UnityEngine;
using UnityEngine.EventSystems;



public class ARObjectInteraction : MonoBehaviour, IPointerClickHandler
{
    public GameObject canvasPanel;
    public void OnPointerClick(PointerEventData eventData)
    {
        // Add your desired behavior here when the button is clicked
        canvasPanel.SetActive(!canvasPanel.activeSelf);
        // You can trigger actions, open panels, or perform other actions.
    }

  
}

