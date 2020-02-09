using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

	public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
