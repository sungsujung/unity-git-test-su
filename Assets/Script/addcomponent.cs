using UnityEngine;
using System.Collections;

public class addcomponent : MonoBehaviour {
	private LeapManager _leapManager;
	private float speed = 0.5f; 
	// Use this for initialization
	void Start () {
	
		if(gameObject.rigidbody == null)
		{
			gameObject.AddComponent("Rigidbody");
			gameObject.rigidbody.useGravity = false;
			_leapManager = (GameObject.Find("LeapManager") as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision e)
	{


		if(e.gameObject.name == "Cube")
		{
			Debug.Log("ok");

			e.gameObject.transform.parent = gameObject.transform;
			this.rigidbody.velocity = Vector3.zero;
			bool check = LeapManager.isHandOpen(_leapManager.frontmostHand());

			if( check == false)
			{

			}

			//e.gameObject.AddComponent("Rigidbody");
			//e.gameObject.rigidbody.velocity = Vector3.zero;
		
			//rigidbody.AddForce(new Vector3(0,0,0) * speed, ForceMode.Impulse);

		

		}
	}
}
