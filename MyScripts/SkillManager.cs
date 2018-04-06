using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillManager : MonoBehaviour {

    public NPC bear;
    public NPC gorilla;
    public NPC panther;
    public Player player;
    float  count = 1.0f;
    public GameObject par_1;
    public GameObject par_2;
    float time = 5.0f;
    public GameManager manager;
    bool state = false;
    bool buff = false;
    //public Button skill_1;

    // Use this for initialization

	void Start () {

        par_1.SetActive(false);

        par_2.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
            count -= Time.deltaTime;

        

        /*if(Input.GetKey(KeyCode.Alpha1))
        {
            state = true;
            par_1.SetActive(state);

            player.mp -= 10;


        }

        if(Input.GetKey(KeyCode.Alpha2))
        {


            npc.hp += 10;
            if (npc.hp < 100)
                manager.DispScore(10);
            state = true;
            if (npc.manager.follow == true)
            {
                npc.m_particle.SetActive(state);
                 
            }
            player.mp -= 10;
        }

        if(Input.GetKey(KeyCode.Alpha3))
        {
            state = true;
            par_2.SetActive(state);

            
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            state = true;
            player.m_particle.SetActive(state);

           
        }
        */

        if (count <= 0)
        {
            state = false;

            par_1.SetActive(false);

            par_2.SetActive(false);

            bear.m_particle.SetActive(false);

            panther.m_particle.SetActive(false);

            gorilla.m_particle.SetActive(false);
            //player.m_particle.SetActive(false);


            count = 1.0f;
        }

        if(buff)
        {
            time -= Time.deltaTime;
            if(time<=0)
            {
                
                player.m_particle.SetActive(false);
                player.power = 1;
                time = 5.0f;
                buff = false;
            }

            
        }

        
    }

    public void OnClickFirst()
    {
        state = true;
        

        if (player.energy >= 10)
        {

            par_1.SetActive(state);

            player.mp += 10;

            player.energy -= 10;
        }
    }

    public void OnClickSecond()
    {
        
        
        state = true;
        if (bear.manager.b_follow == true)
        {
            bear.m_particle.SetActive(state);

            if (bear.hp < 500&&player.mp>=10)
            {
                bear.hp += 10;
                manager.DispScore(10);
                player.mp -= 10;
                player.energy += 20;
            }
        }

        if (gorilla.manager.g_follow == true)
        {
            gorilla.m_particle.SetActive(state);

            if (gorilla.hp < 500 && player.mp >= 10)
            {
                gorilla.hp += 10;
                manager.DispScore(10);
                player.mp -= 10;
                player.energy += 20;
            }
        }

        if (panther.manager.p_follow == true)
        {
            panther.m_particle.SetActive(state);

            if (panther.hp < 500 && player.mp >= 10)
            {
                bear.hp += 10;
                manager.DispScore(10);
                player.mp -= 10;
                player.energy += 20;
            }
        }


    }

    public void OnClickThird()
    {
        state = true;
        
        
        if(player.hp<1000&&player.energy>=10)
        {
            par_2.SetActive(state);
            player.energy -= 10;
            player.hp += 100;
        }
    }

    public void OnClickForth()
    {
        
        buff = true;
        
        if(player.energy>=10)
        {
            player.m_particle.SetActive(true);
            player.energy -= 10;
            player.power = 2;
        }
    }
}
