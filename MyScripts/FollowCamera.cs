using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform targrtTr;
	public float dist =10.0f;
	public float height = 3.0f;
	public float dampTrace = 20.0f;

	private Transform tr;
	// Use this for initialization
	void Start () {
	
		tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
	
		tr.position = Vector3.Lerp(tr.position,targrtTr.position-(targrtTr.forward*dist)+(Vector3.up*height),Time.deltaTime*dampTrace);

		tr.LookAt(targrtTr.position);
	}
}
