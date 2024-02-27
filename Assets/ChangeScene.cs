using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChangeToLearnScene() {
        SceneManager.LoadScene("LearnScene");
    }
    public void SceneChangeToHandScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SceneChangeToLegScene()
    {
        SceneManager.LoadScene("LegScene");
    }

    public void SceneChangeToQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }

    public void SceneChangeToHome()
    {
        SceneManager.LoadScene("HomePage");
    }
}
