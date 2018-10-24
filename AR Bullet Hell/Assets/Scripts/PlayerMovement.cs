using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField]
	private GameObject player;
	[SerializeField]
	FixedJoystick joystick;
	[SerializeField]
	private Camera ARCamera;
	[SerializeField]
	private float moveSpeed;
	private float moveH;
	private Vector3 moveDir;
	private Rigidbody rb;
	private bool isMoving;
	[SerializeField]
	private GameObject boundaryLeft;
	[SerializeField]
	private GameObject boundaryRight;
	private Vector3 playerRot;

	// Use this for initialization
	void Start () 
	{
		isMoving = false;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount > 0) 
		{
			Debug.Log("The screen has been touched.");	
		}

		playerRot = player.transform.eulerAngles;

		playerRot.y = ARCamera.gameObject.transform.eulerAngles.y;

		player.transform.eulerAngles = playerRot;
	}
    
	void FixedUpdate()
	{
		moveH = joystick.Horizontal;
		isMoving = (Mathf.Abs(moveH) > 0);
		if (isMoving == true)
		{
			moveDir = new Vector3(moveH, 0);
            transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
		}

		rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundaryLeft.transform.position.x, boundaryRight.transform.position.x), 0);
		//Debug.Log("moveHorizontal = " + moveH);
	}
}
