using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour 
{

	[SerializeField]
	private float moveSpeed;
	private float moveH;
	private Vector3 moveDir;
	private Rigidbody rb;
	private bool isMoving;

	// Use this for initialization
	void Start () 
	{
		//isMoving = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void FixedUpdate()
	{
		//if (Input.GetButton("Left")) 
		//{
		//	transform.position += Vector3.left * moveSpeed * Time.deltaTime;	
		//}

		moveH = CrossPlatformInputManager.GetAxisRaw("Horizontal");
		isMoving = (Mathf.Abs(moveH) > 0);
		if (isMoving == true)
		{
			moveDir = new Vector3(moveH, 0);
            transform.position += moveDir.normalized * moveSpeed * Time.deltaTime;
		}
		Debug.Log("moveHorizontal = " + moveH);
	}

	//public void OnMoveDown() 
	//{
	//	isMoving = true;	
	//}

	//public void OnMoveUp()
    //{
    //    isMoving = false;
    //}
    
	//public void MoveLeft() 
	//{
	//	if (isMoving == true) 
	//	{
 //           transform.position += Vector3.left * moveSpeed * Time.deltaTime;
	//	}
	//}

	//public void MoveRight()
  //  {
		//if (isMoving == true)
    //    {
    //        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    //    }
    //}
}
