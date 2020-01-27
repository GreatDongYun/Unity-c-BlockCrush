using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour {

	public Transform tr; // Transfrom을 담아줄 변수 생성

	public float speed = 100.0f; //Ball의 속도 

	public GameObject ballPrefab;

	public Transform newBallTr; //Ball이 Player를 따라다니게 할 변수

	public bool is_Shoot = false;

	public AudioClip bounceClip;

	// Use this for initialization
	void Start () {

		tr = GetComponent<Transform> ();  //tr이는 변수안에 transfrom을 담아주겠다 라는 선언

		//공을 생성한다
		OnNewBall();

	}

	public void OnNewBall()
	{
		Vector3 initPos = tr.position + Vector3.up * 1.2f;

		Quaternion initRot = Quaternion.identity;

		GameObject newBall = (GameObject)Instantiate (ballPrefab, initPos, initRot);

		newBallTr = newBall.GetComponent<Transform> ();

		BlockGameManager.Instance.BallCount += 1;
	}

	// Update is called once per frame
	void Update () {

		if (BlockGameManager.Instance.Is_GameOver) 
		{
			if (Input.GetKeyDown (KeyCode.Return)) {
				SceneManager.LoadScene ("Sctitle");
			}
		} 
		else
		{

			//움직인다!
			OnMove ();


			//공발사!!
			OnShoot ();
		}
	}

	public void OnMove()
	{
		//왼쪽으로!
		if (Input.GetKey (KeyCode.A)) 
		{
			tr.Translate (Vector3.left * speed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.D)) // 오른쪽으로!
		{
			tr.Translate (Vector3.right * speed * Time.deltaTime);

		}
	}

	//공을 발사하는 로직! 발사전에는 플레이어를 따다닌다!
	public void OnShoot(){
		if(!is_Shoot)


			newBallTr.position = tr.position + Vector3.up * 1.2f;

		if(Input.GetKeyDown(KeyCode.Space)) //스페이스바를 누면 공이 나간다!
		{
			Rigidbody ballRigidbody = newBallTr.GetComponent<Rigidbody> ();
			if (ballRigidbody != null)
			{
				is_Shoot = true;
				ballRigidbody.AddForce (Vector3.up * 300.0f);
			}
		}
	}

	private void OnCollisionEnter(Collision collision){

		//반사각!
		if(collision.gameObject.CompareTag("BALL"))
		{

			AudioManager.Instance.OnPlayerOneShot (bounceClip);

			Vector3 reflect = collision.transform.position - tr.position;

			float result = 0.0f;

			if(reflect.x > 0)
			{ 
				result = 1.0f;
			}
			else if(reflect.x < 0)
			{
				result = -1.0f;
			}		

			collision.rigidbody.AddForce (new Vector3 (150.0f * result, 50.0f, 0.0f));
		}
	}
}
