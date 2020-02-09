using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public Transform player;

    public float pos = 0f;

    public Text scoreText;

    public bool started;

    public PlayerMovement movement;

    private void Start()
    {
        pos = 0;
    }

    public bool getStarted()
    {
        if (Input.anyKey)
        {
            started = true;
        }

        return started;
    }

    // Update is called once per frame
    void FixedUpdate () {
        getStarted();
        if (started && movement.enabled == true && player.GetComponent<PlayerMovement>().inContact == true)
        {
            pos += 10 * Time.deltaTime;
            scoreText.text = pos.ToString("0");
        }
	}
}
