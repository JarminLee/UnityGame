using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour {
	public Player player;

	public float speed = 1.0f;

	public NPCobject npcObj;

    public GameManager manager;

    

    public GameObject m_particle;

    public SkillManager s_manager;

    public Enemy enemy;

    public Animator b_ani;
    public Animator p_ani;
    public Animator g_ani;

    public float hp = 200;
    private float initHp;
    public Image imgHpbar;

    

    void Start()
	{

        m_particle.SetActive(false);
        //gameObj.SetActive (false);
        b_ani = GetComponent<Animator>();
        p_ani = GetComponent<Animator>();
        g_ani = GetComponent<Animator>();
        initHp = 1000;

    }

	void Update()
	{
        imgHpbar.fillAmount = (float)hp / (float)initHp;

        

        if (hp <= 0)
        {
            Destroy(gameObject);
            
        }

        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit mHi;
		if (Physics.Raycast(mRay, out mHi))
		{
			
			if (mHi.collider.gameObject.tag == "BEAR")
			{
				if(Input.GetMouseButton(0))
				{
					
					npcObj.bear.SetActive (true);
				}
			}

            if (mHi.collider.gameObject.tag == "PANTHER")
            {
                if (Input.GetMouseButton(0))
                {

                    npcObj.panther.SetActive(true);
                }
            }

            if (mHi.collider.gameObject.tag == "GORILLA")
            {
                if (Input.GetMouseButton(0))
                {

                    npcObj.groilla.SetActive(true);
                }
            }
        }

		if(Vector3.Distance(manager.Bear.transform.position,player.transform.position)>7)
		{

            if (manager.b_follow == true)
            {
                
                B_PetFollow();

            }

            else
            {
                b_ani.SetInteger("run", 0);
                b_ani.SetInteger("attack", 0);
                b_ani.SetInteger("walk", 0);
            }


        }

        if (Vector3.Distance(manager.Panther.transform.position, player.transform.position) > 7)
        {

            if (manager.p_follow == true)
            {

                P_PetFollow();

            }

            else
            {
                p_ani.SetInteger("run", 0);
                p_ani.SetInteger("attack", 0);
                p_ani.SetInteger("walk", 0);
            }


        }

        if (Vector3.Distance(manager.Gorilla.transform.position, player.transform.position) > 7)
        {

            if (manager.g_follow == true)
            {

                G_PetFollow();

            }

            else
            {
                g_ani.SetInteger("run", 0);
                g_ani.SetInteger("attack", 0);
                g_ani.SetInteger("walk", 0);
            }


        }

       

        
        
        
        transform.LookAt(player.transform.position);

    }


	public void B_PetFollow()
	{

        manager.Bear.transform.position = Vector3.Lerp (manager.Bear.transform.position, player.transform.position, Time.deltaTime * speed);

        if (player.stateInfo.IsName("RUN00_F"))
        {
            b_ani.SetInteger("run", 1);
            b_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("RUN00_R"))
        {
            b_ani.SetInteger("run", 1);
            b_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("RUN00_L"))
        {
            b_ani.SetInteger("run", 1);
            b_ani.SetInteger("attack", 0);
        }

        if(player.stateInfo.IsName("WAIT00"))
        {
            b_ani.SetInteger("run", 0);

            b_ani.SetInteger("walk", 0);
        }

       

        if (player.stateInfo.IsName("WALK00_B"))
        {
            b_ani.SetInteger("walk", 1);
            b_ani.SetInteger("attack", 0);
            b_ani.SetInteger("run", 0);
        }

        else
            b_ani.SetInteger("walk", 0);

        //Attack();
	}

    public void P_PetFollow()
    {

        manager.Panther.transform.position = Vector3.Lerp(manager.Panther.transform.position, player.transform.position, Time.deltaTime * speed);

        if (player.stateInfo.IsName("RUN00_F"))
        {
            p_ani.SetInteger("run", 1);
            p_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("RUN00_R"))
        {
            p_ani.SetInteger("run", 1);
            p_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("RUN00_L"))
        {
            p_ani.SetInteger("run", 1);
            p_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("WAIT00"))
        {
            p_ani.SetInteger("run", 0);

            p_ani.SetInteger("walk", 0);
        }



        if (player.stateInfo.IsName("WALK00_B"))
        {
            p_ani.SetInteger("walk", 1);
            p_ani.SetInteger("attack", 0);
            p_ani.SetInteger("run", 0);
        }

        else
            p_ani.SetInteger("walk", 0);

        //Attack();
    }

    public void G_PetFollow()
    {

        manager.Gorilla.transform.position = Vector3.Lerp(manager.Gorilla.transform.position, player.transform.position, Time.deltaTime * speed);

        if (player.stateInfo.IsName("RUN00_F"))
        {
            g_ani.SetInteger("run", 1);
            g_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("RUN00_R"))
        {
            g_ani.SetInteger("run", 1);
            g_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("RUN00_L"))
        {
            g_ani.SetInteger("run", 1);
            g_ani.SetInteger("attack", 0);
        }

        if (player.stateInfo.IsName("WAIT00"))
        {
            g_ani.SetInteger("run", 0);

            g_ani.SetInteger("walk", 0);
        }



        if (player.stateInfo.IsName("WALK00_B"))
        {
            g_ani.SetInteger("walk", 1);
            g_ani.SetInteger("attack", 0);
            g_ani.SetInteger("run", 0);
        }

        else
            g_ani.SetInteger("walk", 0);

        //Attack();
    }

   /* void Attack()
    {
        AnimatorStateInfo b_stateInfo = b_ani.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo p_stateInfo = p_ani.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo g_stateInfo = g_ani.GetCurrentAnimatorStateInfo(0);
        if (Vector3.Distance(manager.Bear.transform.position, enemy.transform.position) < 10)
        {
            b_ani.SetInteger("attack", 1);
            b_ani.SetInteger("run", 0);
            if(b_stateInfo.IsName("Attack"))
            {
                enemy.hp -= 1;
                hp -= 1;

            }
        }

        else
            b_ani.SetInteger("attack", 0);

        if (Vector3.Distance(manager.Panther.transform.position, enemy.transform.position) < 10)
        {
            p_ani.SetInteger("attack", 1);
            p_ani.SetInteger("run", 0);
            if (p_stateInfo.IsName("Attack"))
            {
                enemy.hp -= 1;
                hp -= 1;
            }
        }

        else
            p_ani.SetInteger("attack", 0);

        if (Vector3.Distance(manager.Gorilla.transform.position, enemy.transform.position) < 10)
        {
            g_ani.SetInteger("attack", 1);
            g_ani.SetInteger("run", 0);
            if (g_stateInfo.IsName("Attack"))
            {
                enemy.hp -= 1;
                hp -= 1;
            }
        }

        else
            g_ani.SetInteger("attack", 0);
    }*/

}
