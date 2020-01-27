using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCtrl : MonoBehaviour {

	public Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {

		myRigidbody = GetComponent<Rigidbody> ();

		myRigidbody.AddForce (Vector3.up * 1000.0f); //AddForce라는 함수를 통해서 힘을 가해준다.(방향*속력)
		
	}

	// GameOverWall 만나면 볼 카운트를 감소시켜 게임을 종료함
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("GameOverWall")) {
			BlockGameManager.Instance.OnBallCountSub ();



			Destroy (this.gameObject);		
		
		}

	}

}
