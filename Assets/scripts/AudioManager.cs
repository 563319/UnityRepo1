using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    [Header("--------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio  -----------")]
    public AudioClip background1;
    public AudioClip background2;
    public AudioClip background3;
    public AudioClip background4;
    public AudioClip shoot;
    public AudioClip enemyDeath;
    public AudioClip coinPickup;
    public AudioClip jump;
    public AudioClip land;
    public AudioClip tp;

    void Start()
    {


        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            musicSource.Stop();
            musicSource.clip = background1;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            musicSource.Stop();
            musicSource.clip = background2;
            musicSource.Play();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            musicSource.Stop();
            musicSource.clip = background3;
            musicSource.Play();
        }
        

    }

    
   


   
}
