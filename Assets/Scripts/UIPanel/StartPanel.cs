using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartPanel : BasePanel {
    
    private Button m_userBtn;
    private Button m_serverBtn;
    private Button m_startBtn;

    private void Start()
    {
        m_userBtn = transform.Find("Btn_user").GetComponent<Button>();
        m_serverBtn = transform.Find("Btn_server").GetComponent<Button>();
        m_startBtn = transform.Find("Btn_start").GetComponent<Button>();

        m_userBtn.onClick.AddListener(OnUserBtnClick);
        m_userBtn.onClick.AddListener(OnServerBtnClick);
        m_userBtn.onClick.AddListener(OnStartBtnClick);
    }

    public override void OnEnter()
    {
        gameObject.SetActive(true);
    }

    public override void OnExit()
    {
        StartCoroutine(HidePanel());
    }

    public override void OnResume()
    {
        gameObject.SetActive(true);
    }
    public override void OnPause()
    {
        StartCoroutine(HidePanel());
    }

    private void OnUserBtnClick()
    {
        uiMng.PushPanel(UIPanelType.Login);
    }
    private void OnServerBtnClick()
    {

    }
    private void OnStartBtnClick()
    {

    }

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    } 
}
