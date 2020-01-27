using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCtrl : MonoBehaviour {

	public void OnGameStartBtn()
	{
		SceneManager.LoadScene ("ScPlay007");
	}

	public void OnExitBtn()
	{
		Debug.Log ("종료버튼!");
		Application.Quit ();
	}

}
