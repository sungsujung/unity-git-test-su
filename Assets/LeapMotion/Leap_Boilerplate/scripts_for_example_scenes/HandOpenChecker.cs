using UnityEngine;
using System.Collections;

public class HandOpenChecker : MonoBehaviour {
	//립매니져. 
	private LeapManager _leapManager;
	// GUI텍스트.
	private TextMesh text;
	//타임 컴포넌트 가져온것. 
	private TimeCountChecker count;

	private GameObject handOpen;


	// Use this for initialization
	void Start () {
		//텍스트 매쉬 설정.
		text = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
		//립 매니저 찾아 설정.
		_leapManager = (GameObject.Find("LeapManager") as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;
		//타임 부분 스크립트 가져오기.
		count = GameObject.Find ("Time Count").GetComponent<TimeCountChecker>();


	}
	
	// Update is called once per frame
	void Update () {
		//텍스트를 변경.
		text.text = " One : ";

		//손가락이 한개면.
		if (_leapManager.frontmostHand ().Fingers.Count == 1) {
			//디버그.
			Debug.Log("one");
			//카운트 시작을 아니요로 바꿔줌.
			count.begin = false;
			text.text = "Complate";

		}

	}
}
