using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCobject : MonoBehaviour {

	public GameObject bear;
    public GameObject panther;
    public GameObject groilla;


	void Start () {
		
	}
	
	// Update is called once per frame
	public void OnClickLeave () {
        bear.SetActive(false);
        panther.SetActive(false);
        groilla.SetActive(false);
	}

    public void OnClickLeft()
    {
        this.gameObject.SetActive(false);
    }
}
