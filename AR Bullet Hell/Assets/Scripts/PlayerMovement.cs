using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class Boundary
{
	public float minLeft, minRight;	
}

public class PlayerMovement : MonoBehaviour 
{

	[SerializeField]
	private float moveSpeed;
	private float moveH;
	private Vector3 moveDir;
	private Rigidbody rb;
	private bool isMoving;
	[SerializeField]
	private Boundary boundary;

	// Use this for initialization
	void Start () 
	{
		isMoving = false;
		rb = GetComponent<Rigidbody>();
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

		rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.minLeft, boundary.minRight), 0);
		Debug.Log("moveHorizontal = " + moveH);
	}

	public void OnMoveDown() 
	{
		isMoving = true;	
	}

	public void OnMoveUp()
    {
        isMoving = false;
    }
    
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
