using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Common;

public class LoginPanel : BasePanel {
    
    private InputField m_idIF;
    private InputField m_passwordIF;
    private LoginRequest loginRequest;
    //private Button loginButton;
    //private Button registerButton;
    private void Start()
    {
        // loginRequest = GetComponent<LoginRequest>();
        m_idIF = transform.Find("Input_ID").GetComponent<InputField>();
        m_passwordIF = transform.Find("Input_password").GetComponent<InputField>();
        transform.Find("Btn_close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
        transform.Find("Btn_login").GetComponent<Button>().onClick.AddListener(OnLoginClick);
        transform.Find("Btn_register").GetComponent<Button>().onClick.AddListener(OnRegisterClick);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        EnterAnimation();
    }

    public override void OnPause()
    {
        HideAnimation();
    }
    public override void OnResume()
    {
        EnterAnimation();
    }

    public override void OnExit()
    {
        HideAnimation();
    }

    private void OnLoginClick()
    {
        PlayClickSound();
        string msg = "";
        if(string.IsNullOrEmpty(m_idIF.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(m_passwordIF.text))
        {
            msg += "密码不能为空 ";
        }
        if (msg != "")
        {
            uiMng.ShowMessage(msg);return;
        }
     //   loginRequest.SendRequest(usernameIF.text, passwordIF.text);
    }

    public void OnLoginResponse()
    {
        
    }

    private void OnRegisterClick()
    {
        PlayClickSound();
        uiMng.PushPanel(UIPanelType.Register);
    }


    private void EnterAnimation()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.2f);
        transform.localPosition = new Vector3(1000, 0, 0);
        transform.DOLocalMove(Vector3.zero, 0.2f);
    }
    private void HideAnimation()
    {
        transform.DOScale(0, 0.3f);
        transform.DOLocalMoveX(1000, 0.3f).OnComplete(() => gameObject.SetActive(false));
    }
}
