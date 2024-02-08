using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSpawner : MonoBehaviour
{
    public GameObject axePrefab;
    public float axeFrequency;
    private bool axeToggle = false;
    private float axeTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        axeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        axeTimer += Time.deltaTime;
        if(axeTimer >= axeFrequency && axeToggle)
        {
            SpawnAxe();
            axeTimer = 0;
        }
    }

    public void SpawnAxe()
    {
        Instantiate(axePrefab, new Vector2(10,Random.Range(-4,4)) , Quaternion.identity);
    }
    
    public void AxeToggle()
    {
        axeToggle = !axeToggle;
    }
}
