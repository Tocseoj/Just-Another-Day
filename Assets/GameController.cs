using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController control;
    public int currentScene = 0;

	// Days
	public int day = 0;
	public int[] score = new int[10];
	public int total {
		get {
			int t = 0;
			for (int i = 0; i < score.Length; i++) {
				t += score[i];
			}
			return t;
		}
	}
	public bool[] hidden = new bool[10];
	//

	// Music
	public AudioClip[] soundtracks;
	int currentTrack = 0;
	public AudioSource audioSource;
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
		PlayMorningMusic();
		currentTrack = 1;
		//
    }

    public void NextScene()
    {
        currentScene = currentScene + 1;
		if (currentScene > SceneManager.sceneCountInBuildSettings - 2) {
			day++;
			currentScene = 1;
			if (day > 4) {
				SceneManager.LoadScene("EndScene");
			} else {
				SceneManager.LoadScene(currentScene);
			}
		} else {
			SceneManager.LoadScene(currentScene);
		}
    }

	void OnLevelWasLoaded(int level) {
		if (level == 1) {
			PlayNextTrack();
		}
		if (level == 10) {
			PlayEndMusic();
		}
		if (level == 11) {
			audioSource.Stop();
			audioSource.clip = soundtracks[5];
			audioSource.volume = 0.5f;
			audioSource.Play();
		}
	}

	void PlayNextTrack() {
		audioSource.Stop();
		currentTrack = UnityEngine.Random.Range(1, 4);
		audioSource.clip = soundtracks[currentTrack];
		if (currentTrack == 1)
			audioSource.volume = 0.2f;
		if (currentTrack == 2)
			audioSource.volume = 0.25f;
		if (currentTrack == 3)
			audioSource.volume = 0.5f;
		audioSource.Play();
		//currentTrack++;
		//if (currentTrack >= soundtracks.Length - 2)
		//	currentTrack = 1;
	}

	public void PlayMorningMusic() {
		audioSource.Stop();
		audioSource.clip = soundtracks[0];
		audioSource.volume = 0.07f;
		audioSource.Play();
	}

	void PlayEndMusic() {
		audioSource.Stop();
		audioSource.clip = soundtracks[4];
		audioSource.volume = 0.5f;
		audioSource.Play();
	}

    public void Save()
    {
        //Load in the file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        // Brings in the SaveData 
        SaveData data = new SaveData();

        // Save to SaveData here
        data.setHighScores(score);

        // Loads file with data.
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/saveData.dat"))
        {
            //Don't worry about this too much.
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/saveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();

            //Load in the data from the file
            score = data.getHighScores();
        }
    }
}

[Serializable]
class SaveData
{
    //Variable save locations. Private so people can't change them.
    private int[] highScores;

    //Set Variables
    public void setHighScores(int[] b) { highScores = b; }

    //Get Variables
    public int[] getHighScores() { return highScores; }
}