
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Coin : MonoBehaviour
{
    public PlayerScript objectOne;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") == true)
        {


            objectOne.playerScore += 1;
            
            Destroy(gameObject);
        }
    }
    
}
