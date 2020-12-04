using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGeneration : MonoBehaviour 
{
    public GameObject asteroidPrefab;
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
        GameObject a = Instantiate(asteroidPrefab, transform) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
        numofobj = numofobj - 1;
        }
    }
    IEnumerator asteroidWave(){
        
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}

