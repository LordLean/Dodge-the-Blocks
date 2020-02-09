using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public GameObject player;

    public PlayerMovement movement; 

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);

        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<gameManager>().endGame();
        }
        if (collision.collider.tag == "Floor")
        {
            //Debug.Log("TOUCHING FLOOR");
            player.GetComponent<PlayerMovement>().inContact = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Floor")
        {
            player.GetComponent<PlayerMovement>().inContact = false;
        }
    }
}
