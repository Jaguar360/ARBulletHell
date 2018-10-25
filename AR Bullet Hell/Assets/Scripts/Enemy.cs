﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private bool dead = false;
	public GameObject projectile;
	private GameManager gameManager;

	private void Awake()
	{
        gameManager = FindObjectOfType<GameManager>();
		StartCoroutine(Shoot());      
	}

	private void Start()
	{
		Debug.Log("Game manager: " + gameManager);
	}

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
    
	public IEnumerator Shoot()
    {
		while (gameManager.IsGameOver() == false) 
		{
            yield return new WaitForSeconds(1);
            GameObject bullet = (GameObject)Instantiate(projectile);
            bullet.transform.position = transform.position + transform.forward;
            bullet.transform.forward = transform.forward;
		}
    }
}
