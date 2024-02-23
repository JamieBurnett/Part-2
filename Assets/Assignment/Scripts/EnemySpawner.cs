using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float enemyTimer;
    private float enemyMaxTime = 4;
    private float xPos;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        enemyTimer += Time.deltaTime;
        if(enemyTimer >= enemyMaxTime)
        {
            Instantiate(enemy,new Vector2(xPos,yPos),Quaternion.identity);
            enemyTimer = 0 + Random.Range(0, 4);
        }
    }

    private void randomPosition()
    {
        if (Random.Range(1, 2) > 1.5)
        {
            xPos = 10;
        }
        else
        {
            xPos = -10;
        }
        yPos = Random.Range(-5, 5);
    }
}
