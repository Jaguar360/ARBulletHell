using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

	[SerializeField]
	private float moveSpeed;
	private Vector3 moveDir;
	private bool pressHorizontal;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		//if (Input.GetButton("Left")) 
		//{
		//	transform.position += Vector3.left * moveSpeed * Time.deltaTime;	
		//}
	}

	public void MoveLeft() 
	{
		transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	}

	public void MoveRight()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }
}
