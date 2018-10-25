using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private bool dead = false;
	public GameObject projectile;

	private void Awake()
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
		while (true) 
		{
            yield return new WaitForSeconds(1);
            Debug.Log("Shooting");
            GameObject bullet = (GameObject)Instantiate(projectile);
            bullet.transform.position = transform.position + transform.forward;
            bullet.transform.forward = transform.forward;
		}
    }
}
