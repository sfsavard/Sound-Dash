using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition; //making a variable for the last know position of the player to be used by the camera since the camera is a 3D object (needs Vector3)
    private float distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>(); //gets the parameteres from our player controller script and adds it to thePlayer
        lastPlayerPosition = thePlayer.transform.position; //want a value right at the start of the game as well
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x; //distance to move is equal to the difference in x from now to the last known position

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z); //want to change our current transform position to move with the distance of the player but not change in the y or z

        lastPlayerPosition = thePlayer.transform.position; //takes transform position of the player during that frame
    }
}
