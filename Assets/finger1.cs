using UnityEngine;
using System.Collections;
using Leap;
public class finger1 : MonoBehaviour {
	private LeapManager _leapManager;
	// Use this for initialization
	void Start () {
		_leapManager = (GameObject.Find("LeapManager")as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
	}
	
	// Update is called once per frame
	void Update () {
		Hand primeHand = _leapManager.frontmostHand();
		if(primeHand.IsValid)
		{
			Debug.Log("hand found ");



		}
	}


}
