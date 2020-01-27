using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverImgCtrl : MonoBehaviour {

	private Text overText;
	private Image overImg;

	// Use this for initialization
	void Start () {

		overText = GetComponentInChildren<Text> ();
		overImg = GetComponent<Image> ();

		overText.enabled = false;
		overImg.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (BlockGameManager.Instance.Is_GameOver && !overImg.enabled) {
			overText.enabled = true;
			overImg.enabled = true;
		}
	}
}
