using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.SceneManagement;

public class Tpbutton : MonoBehaviour
{
    public PlayerScript playerScript;
    //public float tplocation;
    public float tpx = 0f;
    public float tpy = 0f;
    //public Transform destination;
    //public bool cantp;
    public bool playBackground4;
    AudioManager audioManager;


    public Transform teleportPosition;

   
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        //cantp = playerScript.cantp;

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") == true )
        {
            audioManager.PlaySFX(audioManager.tp);
            //transform.position = new Vector3(enemyX, enemyY, 0);
            playerScript.transform.position = teleportPosition.position + new Vector3(2, 0, 0 );
            //playerScript.transform.position = destination.transform.position;
            if (tpx == -122.17)
            {
                playBackground4 = true;
            }
        }
    }
}
