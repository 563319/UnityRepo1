using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerScript:MonoBehaviour
{ 
    Rigidbody2D rb;
    bool isGrounded;
    public Animator anim;
    public int playerScore;
    public LayerMask groundLayer;
    public int lives;
    HelperScript helper;
    public float speed;
    

    
    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        lives = 5;
        helper = gameObject.AddComponent<HelperScript>();
        speed = 4.7f;

    }

    
    void Update()
    {
        DoRayCollisionCheck();
        float xvel, yvel;

        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;

        if (Input.GetKey("a"))
        {
            xvel = -speed;
            //GetComponent<SpriteRenderer>().flipX = true;
            helper.DoFlipObject(true);


        }
        if (Input.GetKey("d"))
        {
            xvel = speed;
            //GetComponent<SpriteRenderer>().flipX = false;
            helper.DoFlipObject(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown("j") && isGrounded ))
        {
            yvel = 14f;
        }

       

        rb.linearVelocity = new Vector3(xvel, yvel, 0);

        if(xvel >= 0.1f || xvel <= -0.1f )
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        helper.HelloWorld();


    }
    /*public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
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
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
            isGrounded = true;
        }
        
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, -Vector3.up * rayLength, hitColor);

        return hitSomething;

    }
    */

    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.5f; // length of raycast


        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        //raycast color
        Color hitColor = Color.white;

        //raycaster can see ground
        if (hit.collider != null)
        {
            //print("Player has collided with Ground layer");
            hitColor = Color.green;
            isGrounded = true;

            anim.SetBool("isJumping", false);

           
        }
        //raycaster cannot see ground
        if (hit.collider == null)
        {
            isGrounded = false;
            anim.SetBool("isJumping", true);
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, Vector2.down * rayLength, hitColor);
        return hit.collider;

    }


   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("spike") == true)
        {
            SceneManager.LoadScene(0);

        }
        if (collision.gameObject.tag.Equals("Enemy") == true)
        {
            SceneManager.LoadScene(0);

        }
    }
}


































/*
        float PlrX = transform.position.x;
        float PlrY = transform.position.y;
       
        //input
        if (Input.GetKey("w") == true)
        {
            PlrY = PlrY + 0.1f;
        }

        if (Input.GetKey("s") == true)
        {
            PlrY = PlrY - 0.1f;
        }

        if (Input.GetKey("a") == true)
        {
            PlrX = PlrX - 0.1f;
        }

        if (Input.GetKey("d") == true)
        {
            PlrX = PlrX + 0.1f;
        }
        if (Input.GetKey("q") == true)
        {
            Application.Quit();
        }


        //y check
        if (PlrY > 1f)
        {
            PlrY = 1f;
        }

        if (PlrY < -1f)
        {
            PlrY = -1f;
        }
        //x check
        if (PlrX > 1.5f)
        {
            PlrX = 1.5f;
        }

        if (PlrX < -1.5f)
        {
            PlrX = -1.5f;
        }

        //
        transform.position = new Vector3(PlrX, PlrY, 0);
        print("x: " + PlrX + " y: " + PlrY);
        */
