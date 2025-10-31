using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class FatBirdScript : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask playerLayer;
    Rigidbody2D rb;
    public Animator anim;
    float enemyX = 0f;
    float enemyY = 0f;
    public float speed = 1f;
    bool canGoDown = true;
    bool canGoUp = false ;
    public float maxHeight;
    AudioManager audioManager;


    void Start()
    {
        groundLayer = LayerMask.GetMask("Ground");
        playerLayer = LayerMask.GetMask("Player");
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    void Update()
    {
        enemyX = transform.position.x;
        enemyY = transform.position.y;
        transform.position = new Vector3(enemyX, enemyY, 0);
        EnemyMovement();

        // checks for player jumping on top of enemy using raycasts
        if (ExtendedRayCollisionCheckPlayer(0, 2.8f) == true)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(gameObject);
        }
        if (ExtendedRayCollisionCheckPlayer(-0.5f, 2.6f) == true)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(gameObject);
        }
        if (ExtendedRayCollisionCheckPlayer(0.5f, 2.6f) == true)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(gameObject);
        }
        if (ExtendedRayCollisionCheckPlayer(-0.9f, 2.5f) == true)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(gameObject);
        }
        if (ExtendedRayCollisionCheckPlayer(0.9f, 2.5f) == true)
        {
            audioManager.PlaySFX(audioManager.enemyDeath);
            Destroy(gameObject);
        }
        
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.3f; // length of raycast
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
    public bool ExtendedRayCollisionCheckPlayer(float xoffs, float yoffs)
    {
        float rayLength = 0.5f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, playerLayer);

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

    public void EnemyMovement()
    {
        if (transform.position.y >= maxHeight)
        {
            canGoUp = false;
            canGoDown = true;

        }
        if (canGoDown == true)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
            anim.SetBool("isFalling", true);
            anim.SetBool("isOnGround", false);
            anim.SetBool("isIdle", false);
        }
        if (canGoUp == true)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
            anim.SetBool("isOnGround", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isFalling", false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground") == true)
        {
            canGoDown = false;
            canGoUp = true;
            

        }
        
    }
    
    

      
     


    

}
