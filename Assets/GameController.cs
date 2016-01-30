using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController control;
    public float playerScore;
    public int currentScene = 0;

    void Awake()
    {
        if (control == null || control != this)
        {
            DontDestroyOnLoad(this);
            control = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextScene()
    {
        currentScene = currentScene + 1;
        if (currentScene > SceneManager.sceneCountInBuildSettings)
        {
            currentScene = 1;
            SceneManager.LoadScene(currentScene);
        }
        else
            SceneManager.LoadScene(currentScene);
    }
}