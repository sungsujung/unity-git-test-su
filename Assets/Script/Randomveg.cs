using UnityEngine;
using System.Collections;

public class Randomveg : MonoBehaviour {
	private Transform startMarker;
	private Transform endMarker;
	public float speed = 1.0f;
	private float startTime;
	private float journeyLength;
	public Transform target;
	public float smooth = 5.0f;


	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector2.Lerp(startMarker.position, endMarker.position, fracJourney);
	}
}
