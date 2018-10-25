using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour 
{
	public float speed = 0f;
    public float lifeDuration = 2f;
    private float lifeTimer;
    GameManager gameManager;
	private GameObject player;

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
        if (other.gameObject.tag == "Player")
        {
			// kill player or subtract player HP
        }
    }
}
