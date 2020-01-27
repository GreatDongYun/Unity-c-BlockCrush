 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 	 // UI 컴포넌트를 사용하기 위함

public class PointTextCtrl : MonoBehaviour {

	private Text myText;
	public bool is_Best = false;


	// Use this for initialization
	void Start () 
	{
		myText = GetComponent<Text> ();

		BlockGameManager.Instance.OnGetPoint ();

		MyTextUpdate ();


	}
	
	// Update is called once per frame
	void Update () {

		MyTextUpdate ();
	}

	private void MyTextUpdate()
	{
		if (myText!= null)
		{
			if (!is_Best) {
				myText.text = BlockGameManager.Instance.Point.ToString ();
			} else
			{
				
				myText.text = "Best : " + BlockGameManager.Instance.BestPoint.ToString ();
			}

		}
	}

}

