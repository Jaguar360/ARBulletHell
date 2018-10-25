using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 0f;
    public float lifeDuration = 2f;
    public float lifeTimer;
	GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        lifeTimer = lifeDuration;
		gameManager = FindObjectOfType<GameManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            Destroy(this.gameObject);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			Destroy(other.gameObject);
			// award points to player
			gameManager.AddScore(1000);
		}
	}
}