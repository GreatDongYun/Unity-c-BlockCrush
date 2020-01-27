using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource audioSource; //오디오 소스 변수를 만들어 준다

	private static AudioManager instance = null;

	public static AudioManager Instance {
		get {
			if (instance == null) {
				GameObject gameObject = new GameObject ("_AudioManager");
				instance = gameObject.AddComponent<AudioManager> ();
			}
			return instance;
		}
	}

	private void Awake()
	{
		instance = this;

		audioSource = GetComponent<AudioSource> ();
	}

	public void OnPlayerOneShot(AudioClip clip)
	{
		audioSource.PlayOneShot (clip);
	}
}	
