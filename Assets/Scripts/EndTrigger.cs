using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public gameManager gm;

    public void OnTriggerEnter(Collider other)
    {
        //gm.endGame();
        gm.levelCompleted();    
    }

}
