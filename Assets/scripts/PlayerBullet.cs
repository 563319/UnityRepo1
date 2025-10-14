using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "spike" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        
    }
}
