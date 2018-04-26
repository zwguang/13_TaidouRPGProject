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
        m_serverBtn.onClick.AddListener(OnServerBtnClick);
        m_startBtn.onClick.AddListener(OnStartBtnClick);
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
        gameObject.SetActive(false);
    }

    private void OnUserBtnClick()
    {
        uiMng.PushPanel(UIPanelType.Login);
    }
    private void OnServerBtnClick()
    {
        uiMng.PushPanel(UIPanelType.Server);
    }
    private void OnStartBtnClick()
    {
        uiMng.PushPanel(UIPanelType.CharacterSelect);

    }

    public void SetServer(string name, Color color)
    {
        Text text = m_serverBtn.gameObject.transform.Find("Text").GetComponent<Text>();
        text.text = name;
        text.color = color;
    }

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    } 
}
