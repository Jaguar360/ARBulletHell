using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

public class ARController : MonoBehaviour 
{
	private List<DetectedPlane> m_newTrackedPlanes = new List<DetectedPlane>();

	public GameObject GridPrefab;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Session.Status != SessionStatus.Tracking) 
		{
			return;
		}
		Session.GetTrackables<DetectedPlane>(m_newTrackedPlanes, TrackableQueryFilter.New);

		for (int i = 0; i < m_newTrackedPlanes.Count; ++i)
		{
			GameObject grid = Instantiate(GridPrefab, Vector3.zero, Quaternion.identity, transform);

			grid.GetComponent<GridVisualizer>().Initialize(m_newTrackedPlanes[i]);
		}
	}
}
