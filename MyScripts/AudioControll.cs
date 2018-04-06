using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour {

    public AudioSource sdc;

    public float musicVolume;
	// Use this for initialization
	void Start () {

        sdc = GetComponent<AudioSource>();

        musicVolume = 0.5f;

        sdc.volume = musicVolume;
	}
	
	// Update is called once per frame
	
}
