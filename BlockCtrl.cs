using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour {

	public GameObject itemPrefab;

	public AudioClip breakClip; // 변수 생성

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("BALL")) // 공과 충돌하는 과정
		{
			AudioManager.Instance.OnPlayerOneShot (breakClip);

			Vector3 initPos = transform.position;
			Quaternion initRot = Quaternion.identity;

			if(itemPrefab != null)
			{
				
				GameObject newItem = (GameObject)Instantiate(itemPrefab, initPos, initRot);
				newItem.GetComponent<ItemCtrl>().Point = Random.Range(50, 150);

			}

			Destroy (this.gameObject);
				
		}
	}
}
