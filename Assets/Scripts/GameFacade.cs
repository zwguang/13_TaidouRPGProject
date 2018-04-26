using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour {

    private static GameFacade m_gameFacade = null;
    public static GameFacade Instance
    {
        get
        {
            if (m_gameFacade != null)
            {
                m_gameFacade = GameObject.Find("GameFacade").GetComponent<GameFacade>();
            }
            return m_gameFacade;
        }
    }

    public UIManager UIMng;
    public AudioManager AudioMng;
    public RequestManager RequestMng;


    private void Awake ()
    {
        InitManager();
	}
    private void Update ()
    {
        UpdateManager();
	}
    private void OnDestroy()
    {
        DestoryManager();
    }

    private void InitManager()
    {
        UIMng = new UIManager(this);
        AudioMng = new AudioManager(this);
        RequestMng = new RequestManager(this);

        UIMng.OnInit();
        AudioMng.OnInit();
        RequestMng.OnInit();
    }

    private void UpdateManager()
    {
        UIMng.Update();
        AudioMng.Update();
        RequestMng.Update();
    }

    private void DestoryManager()
    {
        UIMng.OnDestroy();
        AudioMng.OnDestroy();
        RequestMng.OnDestroy();
    }
}
