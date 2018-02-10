using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : MonoBehaviour {
	public GameObject chronometerGO;
	public Chronometer chronometerScript;

	public GameObject soundFxGO;
	public SoundFx soundFxScript;

	void Start() {
		chronometerGO = GameObject.FindObjectOfType<Chronometer>().gameObject;
		chronometerScript = chronometerGO.GetComponent<Chronometer>();

		soundFxGO = GameObject.FindObjectOfType<SoundFx>().gameObject;
		soundFxScript = soundFxGO.GetComponent<SoundFx>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<Car>()) {
			soundFxScript.playCrashFx();
			chronometerScript.time = chronometerScript.time - 20;
			Destroy(this.gameObject);
		}
	}
}