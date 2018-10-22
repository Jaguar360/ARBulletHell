using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField]
    private float secondsToLive;
    public GameObject bulletPrefab;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rb != null)
        {
            rb.velocity = direction * speed;
        }
    }

    public void Initialize(Vector2 dir)
    {
        direction = dir;
    }

    void OnColliderEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("possessable")) //(other.name == "possessable")
        {
            PlayerController otherPlayer = other.gameObject.GetComponent<PlayerController>();
            GameManager.Instance.PossessedObj = other.gameObject;

           /* if (otherPlayer.possessedSpore != null)
            {
                Debug.Log("enabling spores");
                otherPlayer.possessedSpore.gameObject.SetActive(true);
            } */

            otherPlayer.enabled = true;
            StartCoroutine(otherPlayer.ReturnToOriginalLocation(10.0f));
            GameManager.Instance.PlayerObj.GetComponent<PlayerController>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<CameraController>().ChangeTarget(other.gameObject.name);
            GameManager.Instance.StartPossessionTimer();
            Destroy(gameObject);
        }

       /* if (other.gameObject.CompareTag("dirtWall"))
        {
            //Debug.Log("velocity of bullet is" + GetComponent<Rigidbody2D>().velocity.x);

            if (GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                GameObject shroomPlatform = (GameObject)Instantiate(shroomPlatformPrefab, this.transform.position, new Quaternion(0, 0f, 0, 0));
                shroomPlatform.transform.localScale = new Vector3(shroomPlatform.transform.localScale.x * -1, shroomPlatform.transform.localScale.y, shroomPlatform.transform.localScale.z);
            }

            else
            {
                GameObject shroomPlatform = (GameObject)Instantiate(shroomPlatformPrefab, this.transform.position, new Quaternion(0, 0, 0, 0));
            }
            Destroy(gameObject);
        } */
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
}
