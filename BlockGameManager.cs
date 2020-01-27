using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour {

	private static BlockGameManager instance = null;

	public static BlockGameManager Instance
	{

		get
		{ 
			if(instance == null)
			{
				GameObject gameObject = new GameObject ("_BlockGameManager");
				instance = gameObject.AddComponent<BlockGameManager>();
			}
			return instance;  

		}
	}

	private int point = 0;
	public int Point
	{
		set { point = value; }
		get { return point; }
			
	}

	private bool is_GameOver = false;
	public bool Is_GameOver
	{
		set { is_GameOver = value; }
		get { return is_GameOver; }
	}

	//GameOver의 기준을 만듬, 공의 갯수가 0이 되면 게임 종료
	private int ballCount = 0;
	public int BallCount {
		set { ballCount = value; }
		get { return ballCount; }
	}

	public void OnBallCountSub()
	{
		BallCount--;
		if(BallCount <= 0)
		{
			is_GameOver = true;
			PlayerPrefs.SetInt ("BestPoint", bestPoint);
		}
	}

	private int bestPoint = 0;
	public int BestPoint
	{
		set { bestPoint = value; }
		get { return bestPoint; }

	}

	public void OnGetPoint()
	{
		bestPoint = PlayerPrefs.GetInt ("BestPoint");
	}


	private void Awake()
	{
		instance = this;
	}
}


