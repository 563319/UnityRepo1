using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class BossScript : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask groundLayer;
    bool startMove = true;
    bool left = false;
    bool right = true;
    public float rightEnemySpeed = 2f;
    public float leftEnemySpeed = -2f;
    public PlayerScript playerScript;
    HelperScript helper;
   public int enemyHealth = 20;
    int counter = 0;
    public Animator anim;

    //bool isIdle = true;
    //bool isSpikeing = false
    
    bool isHit;
    bool isIdleYS;
    bool isIdleNS;
    bool spikesIn;
    bool spikesOut;
   



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
        helper = gameObject.AddComponent<HelperScript>();
        
        isIdleNS = true;
        //isIdleYS = false;
        //spikesIn = false;
        //spikesOut = false;
        


    }


    void Update()
    {
        Death();
        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (startMove == true)
        {
            xvel = rightEnemySpeed;
        }
        if (ExtendedRayCollisionCheck(-2, 0.8f) == true)
        {
            right = true;
            left = false;
            startMove = false;
            counter ++;
        }
        if (ExtendedRayCollisionCheck(2f, 0.8f) == true)
        {
            left = true;
            right = false;
            startMove = false;
            counter ++;
        }

        if (right == true)
        {
            xvel = rightEnemySpeed;
            GetComponent<SpriteRenderer>().flipX = true;
            
        }
        if (left == true)
        {
            xvel = leftEnemySpeed;
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
        /////////////////////////////////////////////////


        if( counter == 2 )
        {
            counter=0;
            //toggle animation

            if (anim.GetBool("idlein") == true)
            {
                anim.SetBool("spikesOut", true);
                return;
            }

            if (anim.GetBool("idleOut") == true)
            {
                anim.SetBool("spikesOut", true);
                return;
            }

        }

        return;
        if (counter % 2 == 0)
        {
            if (anim.GetBool("idleOut") == true)
            {
                spikesIn = true;
            }
            if (anim.GetBool("idleIn") == true)
            {
                spikesOut = true;
            }
        }
        if (counter % 2 != 0)
        {
            if (anim.GetBool("spikesOut") == true)
            {
                isIdleYS = true;
            }
            if (anim.GetBool("spikesIn") == true)
            {
                isIdleNS = true;
            }
        }



        if (isIdleYS == true)
        {
            anim.SetBool("idleOut", true);
        }
        if (isIdleNS == true)
        {
            anim.SetBool("idleIn", true);
        }
        if (spikesIn == true)
        {
            anim.SetBool("spikesIn", true);
        }
        if (spikesOut == true)
        {
            anim.SetBool("spikesOut", true);
        }

       


















        /*
        if (counter % 2 == 0)
        {
            isIdle = false;
            isSpikeing = true;
        }
        if (counter % 2 != 0)
        {
            isSpikeing = false;
            isIdle = true;
        }

        /*
        if (isSpikeing == true)
        {
            //anim.SetBool("spikesOut", true);
            
            if (anim.GetBool("idleIn") == false)
            {
                anim.SetBool("spikesOut", true);

            }
            if (anim.GetBool("idleOut") == false)
            {
                anim.SetBool("spikesIn", true);
            }
            // anim.SetBool("spikesOut", true);
            // anim.SetBool("spikesOut", true);
            
        }
        
        if (isIdle == true)
        {
            
            if (anim.GetBool("spikesOut"))
            {  
                anim.SetBool("idleOut", true);
            }

            if (anim.GetBool("spikesIn"))
            {
                anim.SetBool("idleIn", true);
            }
            

        }
        */






        rb.linearVelocity = new Vector3(xvel, yvel, 0);



        if (enemyHealth < 4)
        {
            GetComponent<SpriteRenderer>().color = Color.paleVioletRed;
            
        }
        if (enemyHealth < 2)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }


    }


    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayer);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            //print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }

        if (hit.collider == null)
        {

            hitColor = Color.green;
            hitSomething = false;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {

            enemyHealth -= 1;
            
            //GetComponent<SpriteRenderer>().color = Color.red;
            //GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }
    



    void Death()
    {
        if (enemyHealth == 0)
        {
            
            Destroy(gameObject);
            
        }
    }


    public void SpikesFullyOut()
    {
        anim.SetBool("idleOut", true);

    }
    
}
