using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Vector2 targetPos;
    public bool walk;

    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        walk = false;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal");
        change.y = Input.GetAxis("Vertical");
        UpdateAnimationAndMove();
        if (walk)
        {
            ClickToMove();
        }
        
    }



    void UpdateAnimationAndMove(){
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);

        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed
        );
    }

    void Check_Touch()
    {
    
    }

    void ClickToMove()
    {
        //float step = moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed);

    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Farm")
        {
        walk = false;
        }

    }

}
