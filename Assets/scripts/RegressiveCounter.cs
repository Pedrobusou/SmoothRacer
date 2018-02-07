using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegressiveCounter : MonoBehaviour {
	public GameObject roadGeneratorGO;
	public RoadGenerator roadGeneratorScript;
	public Sprite[] spriteNumbers = new Sprite[4];

	public GameObject regressiveCountGO;
	public SpriteRenderer regressiveCountComp;

	public GameObject carGO;
	public GameObject carController;

	void Start() {
		initComponents();
		startRegressiveCount();
	}

	void initComponents() {
		roadGeneratorGO = GameObject.FindGameObjectWithTag("roadGenerator");
		roadGeneratorScript = roadGeneratorGO.GetComponent<RoadGenerator>();

		regressiveCountGO = GameObject.FindGameObjectWithTag("regressiveCount");
		regressiveCountComp = regressiveCountGO.GetComponent<SpriteRenderer>();

		carGO = GameObject.FindGameObjectWithTag("Player");
		carController = GameObject.FindGameObjectWithTag("carController");
	}

	IEnumerator counter() {
		carController.GetComponent<AudioSource>().Play(); //engineOn
		yield return new WaitForSeconds(2);

		regressiveCountComp.sprite = spriteNumbers[1]; //2
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		regressiveCountComp.sprite = spriteNumbers[2]; //1
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(1);

		regressiveCountComp.sprite = spriteNumbers[3]; //Go
		roadGeneratorScript.engineOn = true;
		regressiveCountGO.GetComponent<AudioSource>().Play();
		carGO.GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(2);
		regressiveCountGO.SetActive(false);
	}

	void startRegressiveCount() {
		StartCoroutine(counter());
	}

	void Update() {

	}
}