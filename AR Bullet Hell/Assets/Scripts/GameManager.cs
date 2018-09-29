using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private UnityEngine.UI.Button moveLeft;
	[SerializeField]
	private UnityEngine.UI.Button moveRight;

	private bool isAlive;

	// Use this for initialization
	void Start () 
	{
		isAlive = true;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public bool IsAlive() 
	{
		return isAlive;
	}
}
