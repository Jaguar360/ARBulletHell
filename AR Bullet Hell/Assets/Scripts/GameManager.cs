using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	[SerializeField]
	private Camera cam;
	[SerializeField]
	private FixedJoystick joystick;   
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private Text timerText;

	private bool isAlive;
	private int score;
	private float startTime;

	// Use this for initialization
	void Start () 
	{
		isAlive = true;
		scoreText.text = "SCORE: 0";
		score = 0;
		timerText.text = "TIME: 0:00:00";
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isAlive == true)
		{
			score++; // score increases every frame
			DisplayScore();
		}

		float t = Time.time - startTime;

		if (isAlive == true)
		{
			string min = ((int)t / 60).ToString();
			string sec = (t % 60).ToString("f2"); // limit milliseconds to 2 decimals
			timerText.text = "Time: " + min + ":" + sec;
		}
	}

	public bool IsAlive() 
	{
		return isAlive;
	}

	public void DisplayScore()
	{
		if (score >= 9999999)
		{
			scoreText.text = "SCORE: MAX";
		}

		else
		{
            scoreText.text = "SCORE: " + score; 
		}      
	}
}
