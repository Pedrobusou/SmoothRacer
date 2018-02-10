using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScene : MonoBehaviour {
	public Image fade;
	public string[] scenes = new string[2] { "Start", "Game" };

	void Start() {
		fade = GetComponent<Image>();
		fade.CrossFadeAlpha(0, 0.5f, false);
	}

	public void changeScene(int scene) {
		fade.CrossFadeAlpha(1, 0.5f, false);
		StartCoroutine(loadScene(scenes[scene]));
	}

	IEnumerator loadScene(string scene) {
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(scene);
	}
}