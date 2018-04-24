using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : BasePanel {

    private InputField m_idIF;
    private InputField m_passwordIF;
    private InputField m_passwordIF1;
    private LoginRequest loginRequest;
    //private Button loginButton;
    //private Button registerButton;
    private void Start()
    {
        // loginRequest = GetComponent<LoginRequest>();
        m_idIF = transform.Find("Input_ID").GetComponent<InputField>();
        m_passwordIF = transform.Find("Input_password").GetComponent<InputField>();
        m_passwordIF1 = transform.Find("Input_password1").GetComponent<InputField>();
        transform.Find("Btn_close").GetComponent<Button>().onClick.AddListener(OnCloseClick);
        transform.Find("Btn_cancel").GetComponent<Button>().onClick.AddListener(OnCancelClick);
        transform.Find("Btn_register").GetComponent<Button>().onClick.AddListener(OnRegisterAndLoginClick);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override void OnEnter()
    {
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
    
    public void OnCancelClick()
    {
        uiMng.PopPanel();
    }
    private void OnRegisterAndLoginClick()
    {
        string id = m_idIF.text;
        string password = m_passwordIF.text;

        PlayClickSound();
        uiMng.PopPanel();
        uiMng.PopPanel();
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
