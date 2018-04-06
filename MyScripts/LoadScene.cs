using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "PLAYER")
		{
			
			SceneManager.LoadScene ("senlin");
		}

        if(coll.gameObject.tag=="PLAYER_2")
        {
            SceneManager.LoadScene("huanyu");
        }
	}
}
