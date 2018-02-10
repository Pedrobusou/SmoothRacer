using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	public GameObject carGO;

	public float turnAngle = 45;
	public float speed = 25;

	void Start() {
		carGO = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {
		float turnZ = 0;
		transform.Translate(Vector2.right * Input.GetAxis("Horizontal")* speed * Time.deltaTime);
		turnZ = Input.GetAxis("Horizontal")* -turnAngle;

		carGO.transform.rotation = Quaternion.Euler(0, 0, turnZ);
	}
}