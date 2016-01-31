using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController control;
    public int currentScene = 0;

	// Days
	public int day = 0;
	public int[] score = new int[10];
	public bool[] hidden = new bool[10];
	//

	// Music
	public AudioClip[] soundtracks;
	int currentTrack = 0;
	AudioSource audioSource;
	//

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(this.gameObject);
            control = this;
        }
        else
        {
            Destroy(gameObject);
        }

		// Music
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = soundtracks[0];
		audioSource.volume = 0.07f;
		audioSource.Play();
		currentTrack = 1;
		//
    }

    public void NextScene()
    {
        currentScene = currentScene + 1;
		if (currentScene > SceneManager.sceneCountInBuildSettings) {
			day++;
			currentScene = 0;
			if (day == 9) {
				SceneManager.LoadScene(0); // End Scene
			}
			SceneManager.LoadScene(currentScene);
		} else {
			SceneManager.LoadScene(currentScene);
		}
    }

	void OnLevelWasLoaded(int level) {
		if (level == 0) {
			audioSource.Stop();
			audioSource.clip = soundtracks[0];
			audioSource.Play();
		}
		if (level == 1) {
			audioSource.volume = 0.5f;
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