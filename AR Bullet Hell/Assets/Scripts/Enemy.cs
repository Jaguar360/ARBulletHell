using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private bool dead = false;
	public GameObject projectile;
	private GameManager gameManager;

	private void Awake()
	{
        gameManager = FindObjectOfType<GameManager>();      
	}

	private void Start()
	{
        StartCoroutine(Shoot());
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
		Debug.Log("shoot begin");
		while (gameManager.IsGameOver() == false) 
		{
            yield return new WaitForSeconds(3);
            GameObject bullet = (GameObject)Instantiate(projectile);
            bullet.transform.position = transform.position + transform.forward;
            bullet.transform.forward = transform.forward;
			Debug.Log("shooteth");
		}
    }
}
