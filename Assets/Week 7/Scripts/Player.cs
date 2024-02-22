using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer myRenderer;
    public Color highlight;
    public Color normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Selected(bool amChosen)
    {
        if (amChosen)
        {
            myRenderer.color = highlight;
        }
        else
        {
            myRenderer.color = normal;
        }
    }

    private void OnMouseDown()
    {
        Selected(true);
    }
}
