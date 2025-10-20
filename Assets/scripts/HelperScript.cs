using UnityEngine;

public class HelperScript : MonoBehaviour
{

    public void DoFlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

    }

    public bool GetDirection()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        return sr.flipX;

    }


    public void HelloWorld()
    {
        if (Input.GetKey("h"))
        {
           // print("Hello World");
        }
    }
}

