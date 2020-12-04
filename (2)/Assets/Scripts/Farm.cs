using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Farm : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    private float nextActionTimeForUpdate = 0.0f;
    public float periodForUpdate = 0.1f;
    public float period = 0.5f;
    // For update and update farm
    private Rigidbody2D playerObj;
    private bool touch = false;
    private double x, y;
    // Necessary

    public int percent = 0;
    public int level = 1;
    private float levelProduce;
    public int numOfFood = 0;
    public int experinceOfGathering = 0;

    private int distance;
    // Start is called before the first frame update
    void Start()
    {
        levelProduce = (level / 50) + 1;
        playerObj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTimeForUpdate )
        {                
            nextActionTimeForUpdate += periodForUpdate;
            if (touch)
            {
                CheckDisstance();
            }
        }
    }

    void CheckDisstance()
    {
        double x1 = playerObj.transform.position.x;
        double y1 = playerObj.transform.position.y;
        if (percent >= 100)
        {
            experinceOfGathering += 25;
            numOfFood += 1; 
            percent = 0;
            levelProduce = 1 -  (level / 10) ;
        }

        if (experinceOfGathering >= level*100)
        {
            level += 1;
        }

        if (Math.Sqrt((x1 - x)*(x1 - x) + (y1 - y)*(y1 - y)) < 2)
        {
            if (Time.time > nextActionTime )
            {
                nextActionTime += period * levelProduce ;
                percent += 1;

                //Debug.Log(percent + "CYYYKAAAAA" + level);
            }
        } 
        else
           {
               touch = false;
           }
    }


        //If your GameObject starts to collide with another GameObject with a Collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Farm")
        {
        touch = true;
        x = collision.gameObject.transform.position.x;
        y = collision.gameObject.transform.position.y;
        //Output the Collider's GameObject's name
        Debug.Log(collision.gameObject.name + " _____ " + collision.gameObject.tag); //+ " ____ " + x + "___ " + y);
        }
    }

    //If your GameObject keeps colliding with another GameObject with a Collider, do something
    //void OnCollisionStay2D(Collision2D collision)
    //{
        //Check to see if the Collider's name is "Chest"
        
        //Debug.Log(collision.gameObject.name);
    //}
}
