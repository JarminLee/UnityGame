using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_2 : MonoBehaviour {


    public GameManager manager;

    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {


        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mHi;
        if (Physics.Raycast(mRay, out mHi))
        {

            if (mHi.collider.gameObject.tag == "STORK")
            {
                if (Input.GetMouseButton(0))
                {

                    manager.NPC1.enabled = true;
                }
            }

            if (mHi.collider.gameObject.tag == "FOX")
            {
                if (Input.GetMouseButton(0))
                {

                    manager.NPC3.enabled = true;
                }
            }

            if (mHi.collider.gameObject.tag == "ELEPHANT")
            {
                if (Input.GetMouseButton(0))
                {

                    manager.NPC4.enabled = true;
                }
            }

            if (mHi.collider.gameObject.tag == "BUFFALO")
            {
                if (Input.GetMouseButton(0))
                {

                    manager.NPC2.enabled = true;
                }
            }
        }
    }
}
