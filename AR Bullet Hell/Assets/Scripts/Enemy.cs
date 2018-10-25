using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private bool dead = false;

	public void MakeDead(bool ded) 
	{
		dead = ded;
	}

	public bool IsDead() 
	{
		return dead;
	}

	private void Update()
	{
		if (dead == true) 
		{
			Destroy(gameObject);
		}
	}

}
