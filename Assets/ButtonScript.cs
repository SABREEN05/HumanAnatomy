using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject uiToShow;
    public GameObject uiManager;
    public UIManager ui;

    private void Start()
    {
        // Assuming the UIManager is on the same GameObject or is accessible
        uiManager = GameObject.FindGameObjectWithTag("uiManager");
        
        ui = uiManager.GetComponent<UIManager>();
    }
    private void Update()
    {
        // // OnButtonClick();
        //if (uiManager)
        //{
        //    print("ooo");
        //}
        //else
        //{
        //    print("aaaaa");
        //}
    }

    public void OnButtonClick()
    {
        // Show the desired UI when the button is clicked
        ui.ShowUI(uiToShow);
    }
}
