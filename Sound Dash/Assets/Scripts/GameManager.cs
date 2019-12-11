using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController player;
    public Vector3 playerStartPoint;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPoint = player.transform.position;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame() //want it public so other scripts can use it
    {
        StartCoroutine("RestartGameCo"); //a co-routine runs independently of our script. Useful because we could add time delays
    }

    public IEnumerator RestartGameCo()
    {
        music.Stop();
        player.gameObject.SetActive(false); //removes the player game object when dead and restarting
        yield return new WaitForSeconds(0.5f); //adds a 0.5 second delay before restarting
        player.transform.position = playerStartPoint; //sets your player back to the starting position
        player.gameObject.SetActive(true); //remakes our player object
        music.Play();
    }
}
