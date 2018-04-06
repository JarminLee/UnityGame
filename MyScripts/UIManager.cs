using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//场景管理函数库

public class UIManager : MonoBehaviour {
    public AudioControll m_audio;
    GameObject gameObj;
    
	void Start()
	{
		gameObj = this.gameObject;
		gameObj.SetActive (false);//目标开始禁用
        
    }

	public  void OnClickStartButton()
	{
		SceneManager.LoadScene ("chengshi");//加载第一个游戏场景
	}

	public void OnClickQuitButton()
	{
		Debug.Log ("quit");
		Application.Quit ();//退出游戏
	}

	public void OnClickHelpButton()
	{
		
		gameObj.SetActive (true);//对象激活

	}

	public void OnClickBGButton()
	{
		gameObj.SetActive (true);
	}

	public void OnClickLeaveButton()
	{

		gameObj.SetActive (false);//对象禁用
	}


    //声音控制操作

    public void OnClickAudioAdd()
    {
        m_audio.sdc.volume += 0.1f;
        

    }

    public void OnClickBegin()
    {
        m_audio.sdc.Play();
    }
    public void OnClickAudioPause()
    {
        m_audio.sdc.Pause();
    }

    public void OnClickAudioRed()
    {
        m_audio.sdc.volume -= 0.1f;
        
    }

    
    
}

