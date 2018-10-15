using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif

public class ARController : MonoBehaviour 
{
	private List<DetectedPlane> m_newTrackedPlanes = new List<DetectedPlane>();

	public GameObject GridPrefab;
	public GameObject Portal;
	public GameObject ARCamera;

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

		// Check if user touches the screen
		Touch touch;
		if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began) 
		{
			return;
		}

		// Check if user touched a detected plane
		TrackableHit hit;
		TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                TrackableHitFlags.FeaturePointWithSurfaceNormal;
		if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit)) 
		{
			Debug.Log("Detected Plane touched");
			// place object on top of detected plane
			Portal.SetActive(true);

			Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

			Portal.transform.position = hit.Pose.position;
			Portal.transform.rotation = hit.Pose.rotation;

            // have placed objected face camera
			Vector3 cameraPosition = ARCamera.transform.position;
			cameraPosition.y = hit.Pose.position.y;
			Portal.transform.LookAt(cameraPosition, Portal.transform.up);
			Portal.transform.parent = anchor.transform;
		}
	}
}
