using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chronometer : MonoBehaviour {
	public GameObject roadGeneratorGO;
	public RoadGenerator roadGeneratorScript;

	public float time = 120;
	public float distance;

	public Text txtTime;
	public Text txtDistance;

	public Text finalDistanceTxt;

	void Start() {
		roadGeneratorGO = GameObject.FindGameObjectWithTag("roadGenerator");
		roadGeneratorScript = roadGeneratorGO.GetComponent<RoadGenerator>();

		txtTime.text = "2:00";
		txtDistance.text = "0";
	}

	void calculateTimeDistance() {
		distance += Time.deltaTime * roadGeneratorScript.speed;
		txtDistance.text = ((int)distance).ToString();

		time -= Time.deltaTime;
		int minutes = (int)time / 60;
		int seconds = (int)time % 60;
		txtTime.text = minutes.ToString()+ ":" + seconds.ToString().PadLeft(2, '0');
	}

	// Update is called once per frame
	void Update() {
		if (roadGeneratorScript.engineOn) {
			calculateTimeDistance();
		}

		if (time <= 0 && roadGeneratorScript.engineOn) {
			roadGeneratorScript.engineOn = false;
			roadGeneratorScript.gameOver();
			finalDistanceTxt.text = ((int)distance).ToString()+ " m";
			txtTime.text = "0:00";
		}
	}
}