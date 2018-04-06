using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {
    public Animator b_ani;
    public Animator p_ani;
    public Animator g_ani;

    // Use this for initialization
    void Start () {
        b_ani = GetComponent<Animator>();
        p_ani = GetComponent<Animator>();
        g_ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
