using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
    private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void NextScene()
    {
        if(sceneIndex +1 < SceneManager.sceneCountInBuildSettings)
        {
            sceneIndex += 1;
        }
        else
        {
            sceneIndex = 0;
        }
        SceneManager.LoadScene(sceneIndex);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(sceneIndex);

    }

}
