using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class coin : MonoBehaviour
{

    public PlayerScript objectOne;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("score: " + objectOne.playerScore);
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
