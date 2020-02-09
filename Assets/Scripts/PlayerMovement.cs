using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce;

    public float LR_force = 350f;

    public float jumpForce = 10f;

    public bool left, right, up, back;

    public bool inContact, grounded = false;

    public int jumpCount;

    public bool rightChecker()
    {
        if (Input.GetKey("d"))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        return right;
    }

    public bool leftChecker()
    {
        if (Input.GetKey("a"))
        {
            left = true;
        }
        else
        {
            left = false;
        }

        return left;
    }

    public bool jumpChecker()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && inContact )
        {
            up = true;
        }
        else
        {
            up = false;
        }

        return up;
    }

    public bool jumper()
    {
        if (jumpCount > 2 || grounded && Input.GetKeyDown(KeyCode.DownArrow)) 
        {
            rb.AddForce(new Vector3(0, 1000));
            grounded = false;
            jumpCount += 1;
        }
        return grounded;
    }

    public bool backchecker()
    {
        if (Input.GetKeyDown("s"))
        {
            back = true;
        } 
        else
        {
            back = false;
        }

        return back;
    }

     void movement()
     {
        if (Input.anyKey)
        {
            forwardForce = 10000f;
        }
        rightChecker();
        leftChecker();
        jumpChecker();
        backchecker();
     }

    // Update is called once per frame
    void FixedUpdate () {
        movement();
        rb.AddForce(0, -10, forwardForce * Time.deltaTime);

        if (right)
        {
            rb.AddForce(LR_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (left)
        {
            rb.AddForce(-LR_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (up)
        {
            rb.AddForce(0, 1000, 0);
            //rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
        if (jumpCount > 2 || grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(0, 1000));
            grounded = false;
            jumpCount += 1;
        }
        else if (back)
        {
            rb.AddForce(0, 0,-forwardForce* Time.deltaTime - 100);
        }
        if (rb.position.y < 0.4)
        {
            FindObjectOfType<gameManager>().endGame();
        }
	}
}
