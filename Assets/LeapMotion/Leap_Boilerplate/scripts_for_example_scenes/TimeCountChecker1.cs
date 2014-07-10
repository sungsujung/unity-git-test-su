using UnityEngine;
using System.Collections;

public class TimeCountChecker1 : MonoBehaviour {
	//시간제한 5초.
	float timeLimit = 5.0f;
	private LeapManager _leapManager ;

	private TextMesh text;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
		_leapManager = (GameObject.Find("LeapManager") as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
	}
	
	// Update is called once per frame
	void Update () {

		if(timeLimit > 1)
		{
			//시간을 감소 시킴. 
			timeLimit -= Time.deltaTime;
			text.text = "Time Count2: " + timeLimit.ToString();

		}
	

	}
}
