using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGeneration : MonoBehaviour 
{
    public GameObject Bot;
    public float respawnTime = 1.0f;
    public Vector2 screenBounds;
    public int ObjPerBlock = 5;
    public int numofobj = 15;



    // Use this for initialization
    void Start () {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //StartCoroutine(asteroidWave());
            
            spawnEnemy();
            //StartCoroutine(asteroidWave());
    }
    private void spawnEnemy(){
        while (numofobj != 0)
        {
        GameObject a = Instantiate(Bot, transform) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
        a.name = numofobj.ToString();
        numofobj = numofobj - 1;
        }
    }

}

