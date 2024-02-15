using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShieldSceneTrigger : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                sceneIndex = 0;
            }
            else
            {
                sceneIndex += 1;
            }
            SceneManager.LoadScene(sceneIndex);
        
    }
}
