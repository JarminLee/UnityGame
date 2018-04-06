using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{

    public Animator ani;

    public Player player;

    public NPC Bear;
    public NPC Panther;
    public NPC Gorilla;
    int state;

    public float hp = 200;
    private float initHp;
    public Image imgHpbar;

    public GameManager manager;
    // Use this for initialization
    void Start()
    {

        ani = GetComponent<Animator>();
        initHp = hp;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            Attack();

            if (player.stateInfo.IsName("Hit_1"))
            {
                hp -= player.power;
            }

            if (player.stateInfo.IsName("Kick_1"))
            {
                hp -= player.power;
            }

            if (player.stateInfo.IsName("Kick_2"))
            {
                hp -= player.power;
            }


        }

        imgHpbar.fillAmount = (float)hp / (float)initHp;



        if (hp <= 0)
        {
            ani.SetInteger("dead", 1);
        }



        // transform.LookAt(player.position);
    }

    void Attack()
    {
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);

        state = (int)Random.Range(1.0f, 4.0f);

        ani.SetInteger("attack", state);

        if (stateInfo.IsName("Hit"))
        {
            player.hp -= 1;

            if(manager.g_follow)
            {
                Gorilla.hp -= 1;
            }

            if(manager.b_follow)
            {
                Bear.hp -= 1;
            }

            if(manager.p_follow)
            {
                Panther.hp -= 1;
            }
        }



    }

    void OnDead()
    {
        Destroy(this.gameObject);
        

    }

    void OnScore()
    {
        manager.DispScore(10);
    }



}
