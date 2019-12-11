using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject cam;
    public float parallaxEffect; //effect of 1 is completely still, used for furthest background

    private float length, startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x; //gets the length of the sprite
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect)); //gets how far we've moved relative to the camera
        float dist = (cam.transform.position.x * parallaxEffect); //creates a distance based on parallax effect

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length) //checks whether our position is greater than the length of the sprite
        {
            startPos += length; //remake the start position equal to length, so it will loop the background
        }
        else if (temp < startPos - length)
        {
            startPos -= length; //does the same in the opposite direction, doesn't really matter in our auto runner but good to know.
        }
    }
}
