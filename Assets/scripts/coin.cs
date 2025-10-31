
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Coin : MonoBehaviour
{
    public PlayerScript objectOne;
    AudioManager audioManager;
    
    
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") == true)
        {

            audioManager.PlaySFX(audioManager.coinPickup);
            objectOne.playerScore += 1;
            
            Destroy(gameObject);
        }
    }
    
}
