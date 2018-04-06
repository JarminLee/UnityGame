using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Cage : MonoBehaviour {

    public float hp = 200;
    private float initHp;
    public Image imgHpbar;

    public Player player;
    // Use this for initialization
    void Start () {
        initHp = hp;
    }
	
	// Update is called once per frame
	void Update () {
        imgHpbar.fillAmount = (float)hp / (float)initHp;

        if(Vector3.Distance(transform.position,player.transform.position)<10)
        {
            if(Input.GetMouseButton(1))
            {
                hp -= player.power;
                
            }
        }

        if(hp<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
