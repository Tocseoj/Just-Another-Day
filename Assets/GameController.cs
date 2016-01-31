using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController control;
    public float playerScore;
    public int currentScene = 0;

	// Music
	public AudioClip[] soundtracks;
	int currentTrack = 0;
	AudioSource audioSource;
	//

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

		// Music
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = soundtracks[currentTrack];
		audioSource.Play();
		currentTrack = 1;;
		//
    }

    public void NextScene()
    {
        currentScene = currentScene + 1;
		if (currentScene > SceneManager.sceneCountInBuildSettings) {
			currentScene = 1;
			SceneManager.LoadScene(currentScene);
		} else {
			SceneManager.LoadScene(currentScene);
		}
    }

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			PlayNextTrack();
		}
	}

	void PlayNextTrack() {
		audioSource.Stop();
		audioSource.clip = soundtracks[currentTrack];
		audioSource.Play();
		float length = soundtracks[currentTrack].length + 0.2f;
		currentTrack++;
		if (currentTrack >= soundtracks.Length)
			currentTrack = 1;
		Invoke("PlayNextTrack" , length);
	}
}