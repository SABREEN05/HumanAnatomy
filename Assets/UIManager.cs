using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject currentActiveUI;

    // Call this method when you want to show a new UI
    public void ShowUI(GameObject newUI)
    {
        // Deactivate the current active UI if it exists
        print("oooo");
        if (currentActiveUI != null)
        {
            currentActiveUI.SetActive(false);
        }

        // Activate the new UI
        newUI.SetActive(true);

        // Update the current active UI reference
        currentActiveUI = newUI;
    }
}
