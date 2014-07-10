using UnityEngine;
using System.Collections;

public class ThrowObject : MonoBehaviour {

	Vector3 curPosition;
	Vector3 firstPosition;
	float firstTime;
	float lastTime;
	bool isFirstMouseDown = false;	//마우스 다운 체크
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator OnMouseDown()    
	{
		if(!isFirstMouseDown)
		{
			firstTime = Time.deltaTime;
			lastTime = Time.deltaTime;
			firstPosition = transform.position;
			isFirstMouseDown = true;
		}
		
		Vector3 scrSpace = Camera.main.WorldToScreenPoint(transform.position); 
		Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, scrSpace.z));    
		
		//Draggin Object
		while (Input.GetMouseButton(0)){
			//print("offset X : " + offset);
			Vector3 curScreenSpace = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, scrSpace.z);        
			curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;            
			transform.position = curPosition;
			yield return null;
		}
		//현재 오브젝트의 속도 0으로 초기화
		this.rigidbody.velocity = Vector3.zero;
		
		//터치 했을 때 속도에 deltaTime을 누적시켜 속도 유추
		lastTime += Time.deltaTime;
		
		//기본 속도
		float velocity_X = 50.0f;
		float velocity_Y = 50.0f;
		float velocity_z = 50.0f;
		
		curPosition = transform.position;
		
		//거리 / 속도 (/50 은 속도 조절을 위함) -> 초속
		float tmpX = Mathf.Abs(firstPosition.x - curPosition.x) / (lastTime-firstTime) / 50;
		float tmpY = Mathf.Abs(firstPosition.y - curPosition.y) / (lastTime-firstTime) / 50;
		float tmpZ = Mathf.Abs(firstPosition.z - curPosition.z) / (lastTime-firstTime) / 50;
		
		
		/*
		 * 첫 번째 포지션과 마지막 포지션을 비교해서 반대 방향으로 AddForce
		 * 방향 * 기본 가속도 * 초속
		*/
		if(firstPosition.y > curPosition.y)
		{
			this.rigidbody.AddForce(Vector3.down * velocity_Y * tmpY);
		}
		else if(firstPosition.y < curPosition.y)
		{
			this.rigidbody.AddForce(Vector3.up * velocity_Y * tmpY);
		}
		
		
		if(firstPosition.x > curPosition.x)
		{
			this.rigidbody.AddForce(Vector3.right * velocity_X * tmpX);			
		}
		else if(firstPosition.x < curPosition.x)
		{
			this.rigidbody.AddForce(Vector3.left * velocity_X * tmpX);			
		}
		
		if(firstPosition.z > curPosition.z)
		{
			this.rigidbody.AddForce(Vector3.back * velocity_z * tmpZ);
		}
		else if(firstPosition.z < curPosition.z)
		{
			this.rigidbody.AddForce(Vector3.forward * velocity_z * tmpZ);
		}
		
		isFirstMouseDown = false;
	}
}
