using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    public Canvas exit;

    public bool b_follow = false;
    public bool p_follow = false;
    public bool g_follow = false;
    public GameObject LoadPosint0;
    public GameObject Bear;
    public GameObject Panther;
    public GameObject Gorilla;

    public Text txtScore;
    public Text friendCount;
    public Text taskCount;

    private int totScore;
    private int totFriend;
    private int totTask;

    public Player player;

    public GameObject taskObj_1;
    public GameObject taskObj_2;
    public GameObject taskObj_3;
    public GameObject taskObj_4;

    
    public GameObject LoadPosint;

    public Canvas NPC1;
    public Canvas NPC2;
    public Canvas NPC3;
    public Canvas NPC4;

    public GameObject Snake;
    
    void Start()
    {
        LoadPosint0.SetActive(false);
        Snake.SetActive(false);
        exit.enabled = false;
        DispScore(0);
        
        taskObj_1.SetActive(false);
        taskObj_2.SetActive(false);
        taskObj_3.SetActive(false);
        taskObj_4.SetActive(false);
        
        LoadPosint.SetActive(false);
        NPC1.enabled = false;
        NPC2.enabled = false;
        NPC3.enabled = false;
        NPC4.enabled = false;
        

    }

    void Update()
    {
        


        if(Input.GetKey(KeyCode.Escape))
        {
            exit.enabled = true;
                
        }

        if(totFriend==3)
        {
            LoadPosint0.SetActive(true);
        }
        if(totTask==4)
        {
            LoadPosint.SetActive(true);
        }
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mHi;
        if (Physics.Raycast(mRay, out mHi))
        {

            if (mHi.collider.gameObject.tag == "SNAKE")
            {
                if (Input.GetMouseButton(0))
                {

                    Snake.SetActive(true);
                }
            }

            if (mHi.collider.gameObject.tag == "TASKOBJ_1")
            {
                if (Input.GetMouseButton(0))
                {
                    taskObj_1.SetActive(false);

                    if (totTask<4)
                    {
                        totTask += 1;
                        taskCount.text = "收集数× <color=#ff0000>" + totTask.ToString() + "</color>";
                    }
                }
            }

            if (mHi.collider.gameObject.tag == "TASKOBJ_2")
            {
                if (Input.GetMouseButton(0))
                {
                    taskObj_2.SetActive(false);

                    if (totTask < 4)
                    {
                        totTask += 1;
                        taskCount.text = "收集数× <color=#ff0000>" + totTask.ToString() + "</color>";
                    }
                }
            }

            if (mHi.collider.gameObject.tag == "TASKOBJ_3")
            {
                if (Input.GetMouseButton(0))
                {
                    taskObj_3.SetActive(false);

                    if (totTask < 4)
                    {
                        totTask += 1;
                        taskCount.text = "收集数× <color=#ff0000>" + totTask.ToString() + "</color>";
                    }
                }
            }

            if (mHi.collider.gameObject.tag == "TASKOBJ_4")
            {
                if (Input.GetMouseButton(0))
                {
                    taskObj_4.SetActive(false);

                    if (totTask < 4)
                    {
                        totTask += 1;
                        taskCount.text = "收集数× <color=#ff0000>" + totTask.ToString() + "</color>";
                    }
                }
            }
        }

    }

   public void OnClickQuit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

   public void OnClickLeave()
    {
        exit.enabled = false;
    }

   public void OnClickBack()
    {
        SceneManager.LoadScene("Login");
    }

    public void OnClickSnake()
    {
        Snake.SetActive(false);
        player.transform.position=new  Vector3(318, 68, 247);
    }

    public void OnClickB_Follow()
    {
        b_follow = true;
        if (totFriend < 3)
        {
            totFriend += 1;
            friendCount.text = "伙伴数× <color=#ff0000>" + totFriend.ToString() + "</color>";
        }
    }

    public void OnClickP_Follow()
    {
        p_follow = true;
        if (totFriend < 3)
        {
            totFriend += 1;
            friendCount.text = "伙伴数× <color=#ff0000>" + totFriend.ToString() + "</color>";
        }
    }


    public void OnClickG_Follow()
    {
        g_follow = true;
        if (totFriend < 3)
        {
            totFriend += 1;
            friendCount.text = "伙伴数× <color=#ff0000>" + totFriend.ToString() + "</color>";
        }
    }
    public void OnClickB_refuse()
    {
        b_follow = false;
        if(totFriend>0)
        {
            totFriend -= 1;
            friendCount.text = "伙伴数× <color=#ff0000>" + totFriend.ToString() + "</color>";
        }
    }

    public void OnClickP_refuse()
    {
        p_follow = false;
        if (totFriend > 0)
        {
            totFriend -= 1;
            friendCount.text = "伙伴数× <color=#ff0000>" + totFriend.ToString() + "</color>";
        }
    }

    public void OnClickG_refuse()
    {
        g_follow = false;
        if (totFriend > 0)
        {
            totFriend -= 1;
            friendCount.text = "伙伴数× <color=#ff0000>" + totFriend.ToString() + "</color>";
        }
    }

    public void DispScore(int score)
    {
        totScore += score;
        txtScore.text = "和谐值 <color=#ff0000>" + totScore.ToString() + "</color>";
    }

    public void TaskClick_1()
    {
        taskObj_1.SetActive(true);
    }

    public void TaskClick_2()
    {
        taskObj_2.SetActive(true);
    }

    public void TaskClick_3()
    {
        taskObj_3.SetActive(true);
    }

    public void TaskClick_4()
    {
        taskObj_4.SetActive(true);
    }

   
}
