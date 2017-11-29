using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip [] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake(){
		//Ensuring that this object persists throughout the game
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level){
		//Setting each level its own AudioClip from the array
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		
		//If there is an audio clip, attach the audio clip from the array to the audio source and play the audio source
		if(thisLevelMusic){
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	
	public void SetVolume(float newVolume){
		audioSource.volume = newVolume;	
	}
}
