using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win_Fail : MonoBehaviour {

    

    public Canvas win;
    public Canvas fail;

    public Player player;
    public GameObject win1;
    public GameObject win2;
    public GameObject win3;
    public GameObject win_F;
    int win_count = 0;
    void Start()
    {
        
        win.enabled = false;
        fail.enabled = false;
        win_F.SetActive(false);
    }

     void Update()
    {
        Win();

        if (win_count == 3)
        {
            win_F.SetActive(true);
        }

        if (player.hp <= 0)
            fail.enabled = true;

        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mHi;
        if (Physics.Raycast(mRay, out mHi))
        {

            if (mHi.collider.gameObject.tag == "WIN")
            {
                if (Input.GetMouseButton(0))
                {

                    win.enabled = true;
                }
            }
        }

    }

    public void OnClickReagain()
	{
		SceneManager.LoadScene ("Login");
	}

	public void OnClickRebugin()
	{
		SceneManager.LoadScene ("chengshi");
	}

	public void OnClickQuit()
	{
		Debug.Log ("quit");
		Application.Quit ();
	}

    void Win()
    {

        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mHi;
        if (Physics.Raycast(mRay, out mHi))
        {

            if (mHi.collider.gameObject.tag == "WIN1")
            {
                if (Input.GetMouseButton(0))
                {

                    win1.SetActive(false);
                    win_count += 1;
                }
            }

            if (mHi.collider.gameObject.tag == "WIN2")
            {
                if (Input.GetMouseButton(0))
                {

                    win2.SetActive(false);
                    win_count += 1;
                }
            }

            if (mHi.collider.gameObject.tag == "WIN3")
            {
                if (Input.GetMouseButton(0))
                {

                    win3.SetActive(false);
                    win_count += 1;
                }
            }
        }
    }
}
