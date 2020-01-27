using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour {

	private float rotSpeed = 180.0f;
	private Transform myTr;
	private int point = 0;
	public int Point 
	{
		set { point = value; }
		get { return point; }
	}


	// Use this for initialization
	void Start () 
	{

		myTr = GetComponent<Transform> ();
		this.gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * 150.0f);

		this.gameObject.GetComponent<Renderer> ().material.color =
			new Color (Random.Range (0.0f, 1.0f), Random.Range (0.0f, 1.0f), Random.Range (0, 1.0f));

	}
	
	// Update is called once per frame
	void Update () 
	{

		myTr.Rotate (Vector3.forward * rotSpeed * Time.deltaTime);
		
	}

	private void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.CompareTag("Player") && !BlockGameManager.Instance.Is_GameOver)
		{
			BlockGameManager.Instance.Point += point;

			if (BlockGameManager.Instance.BestPoint <= BlockGameManager.Instance.Point)
			{
				BlockGameManager.Instance.BestPoint = BlockGameManager.Instance.Point;
			}



			Destroy (this.gameObject);
		}
	}
}
