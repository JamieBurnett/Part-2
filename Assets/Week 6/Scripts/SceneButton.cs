using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
   

    private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextScene()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex +1 == SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex = 0;
        }
        else
        {
            sceneIndex += 1;
        }
        SceneManager.LoadScene(sceneIndex);
    }
    public void resolutionChangeHD()
    {
        Screen.SetResolution(1920, 1080, false);
        
        
    }
    public void resolutionChange16()
    {
        Screen.SetResolution(1024, 576, false);


    }
}
