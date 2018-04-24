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

    private UIManager m_uiMng;
    private AudioManager m_audioMng;
    private RequestManager m_requestMng;


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
        m_uiMng = new UIManager(this);
        m_audioMng = new AudioManager(this);
        m_requestMng = new RequestManager(this);

        m_uiMng.OnInit();
        m_audioMng.OnInit();
        m_requestMng.OnInit();
    }

    private void UpdateManager()
    {
        m_uiMng.Update();
        m_audioMng.Update();
        m_requestMng.Update();
    }

    private void DestoryManager()
    {
        m_uiMng.OnDestroy();
        m_audioMng.OnDestroy();
        m_requestMng.OnDestroy();
    }
}
