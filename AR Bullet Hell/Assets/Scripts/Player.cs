using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int lives;
	private bool alive;

	// Use this for initialization
	void Awake () 
	{
		lives = 3;
		alive = true;
	}

	void Update()
	{
		if (lives <= 0) 
		{
			Debug.Log("Dead");
			Living(false);	
		}
	}

	public int GetLives() 
	{
		return lives;
	}

	public void SetLives(int l) 
	{
		lives += l;
	}

	public bool IsAlive() 
	{
		return alive;
	}

	public void Living(bool status) 
	{
		alive = status;
	}
}
