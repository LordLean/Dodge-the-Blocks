using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    private float restartDelay = 1f;

	public void endGame()
    {
        Invoke("restart", restartDelay);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void levelCompleted()
    {
        
        Debug.Log("Level Completed");
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

}
