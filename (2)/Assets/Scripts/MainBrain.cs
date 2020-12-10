using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MainBrain : MonoBehaviour
{

    public int privateStorage = 10;
    public GameObject NearObject; //IT IS NEAR FARM
    private bool[] mark ;
    private Vector3 firstPosition;
    private bool BOOLgartheringPerFrame;
    private Farm FarmForBot;


    private float nextActionTime = 0f;
    private float period = 0.5f;
    //TIME


    public float moveSpeed;
    bool Click;
    Vector3 targetPos;
    //Vector3 mousePos;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    //for normal animation and walk


    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        firstPosition = myRigidbody.transform.position;
        BOOLgartheringPerFrame = false;
        FarmForBot = GetComponent<Farm>();

        
        change = myRigidbody.transform.position;
        

        if (privateStorage != FarmForBot.numOfFood)
        {
            mark = new bool[] { true, false, false };
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        UpdateAnimationAndMove();
        change = myRigidbody.transform.position;
        IwantFood();
        if (BOOLgartheringPerFrame)
        {
            gartheringPerFrame();
        }
    }

    private void FixedUpdate()
    {



        if (Input.GetKey(KeyCode.N))
        {

            Debug.Log(targetPos);
            Debug.Log(transform.position);
            Debug.Log(Click);
        }

        if (transform.position == targetPos)
         {
            //Debug.Log("NAXYU");
            Click = false;
            mark[2]= false;
            
         }



        if (Click)
        {

            ClickToMove();
            //Debug.Log("!!!!!!");
        }



    }

    void UpdateAnimationAndMove()
    {
        if (change != myRigidbody.transform.position)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void ClickToMove()
    {
        //float step = moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed);

    }



    void IwantFood()
    {
        
        if (mark[0])
        {
            IfindFarm();
            mark[0] = false; 
            mark[1] = true;          
        }    //run to find near farm
        if (mark[1])
        {
            
            
            walkToFarm();
        }   //run to walk near farm and after gathering
        if (mark[2])
        {
            walkComeBack(firstPosition);
        }       //come back
            // key for repeat 1 0 0
    }
    void IfindFarm()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Farm");

        float closeDistance = Vector3.Distance(myRigidbody.transform.position, taggedObjects[0].transform.position);
        NearObject = taggedObjects[0];

        for (int i = 0; i < taggedObjects.Length; i++)
        {
            if (Vector3.Distance(myRigidbody.transform.position, taggedObjects[i].transform.position) <= closeDistance)
            {
                closeDistance = Vector3.Distance(myRigidbody.transform.position, taggedObjects[i].transform.position);
                NearObject = taggedObjects[i];
            }
        }
    }

    void walkToFarm()
    {
        //targetPos = farmObj.target.position;
        targetPos = NearObject.transform.position;
        //Debug.Log(targetPos);
        Click = true;
    }

    void walkComeBack(Vector3 firstPosition)
    {
        Click = true;
        targetPos = firstPosition;
        
            //Debug.Log("@@@@@@@@@@@@@@@"+firstPosition);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Farm")
        {
        //Debug.Log("targetPos ___" + collision.gameObject.name );
        Click = false; 
        mark[1]= false;
        gathering();
        }

    }
    void gathering()
    {
        
        BOOLgartheringPerFrame= true;
              
    }

    void gartheringPerFrame()
    {
        if (Vector3.Distance(myRigidbody.transform.position, NearObject.transform.position) >= 1)
        {
            if (privateStorage != FarmForBot.numOfFood)
            {
                if (Time.time > nextActionTime )
                {
                
                        nextActionTime += period ;
                        //Debug.Log("YEs");
                
                }
            }
            else
            {
            mark[2]= true;          
            BOOLgartheringPerFrame = false;   
            }
        }
        else
        {
            mark[0] = true;
            mark[1] = false;
            mark[2] = false;
            BOOLgartheringPerFrame = false;
        }
    }
}

