using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFx : MonoBehaviour {
	public AudioClip[] soundFx;
	public AudioSource audioS;

	void Start() {
		audioS = GetComponent<AudioSource>();
	}

	public void playCrashFx() {
		audioS.clip = soundFx[0];
		audioS.Play();
	}

	public void playEndMusic() {
		audioS.clip = soundFx[1];
		audioS.Play();
	}
}