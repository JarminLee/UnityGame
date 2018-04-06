using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toward : MonoBehaviour {

    public Transform player;
    public float y=0.2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(new Vector3(player.position.x,player.position.y+y,player.position.z));
	}
}
