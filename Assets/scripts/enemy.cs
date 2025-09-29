using UnityEngine;

public class enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public LayerMask groundLayer;
    bool startMove = true;
    bool left = false;
    bool right = true;
    public float rightEnemySpeed = 2f;
    public float leftEnemySpeed = -2f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    
    void Update()
    {

        float xvel, yvel;
        xvel = rb.linearVelocity.x;
        yvel = rb.linearVelocity.y;
        if (startMove == true)
        {
            xvel = rightEnemySpeed;
        }
        if (ExtendedRayCollisionCheck(-0.5f, 0) == false)
        {
            right = true;
            left = false;
            startMove = false;
        }
        if (ExtendedRayCollisionCheck(0.5f, 0) == false)
        {
            left = true;
            right = false;
            startMove = false;
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



        rb.linearVelocity = new Vector3(xvel, yvel, 0);




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
}
