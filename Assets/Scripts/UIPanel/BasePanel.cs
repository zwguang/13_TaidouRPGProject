using UnityEngine;
using System.Collections;

public class BasePanel : MonoBehaviour {
    protected UIManager uiMng;
    protected GameFacade facade;

    public UIManager UIMng
    {
        set { uiMng = value; }
    }

    public GameFacade Facade
    {
        set { facade = value; }
    }

    protected void PlayClickSound()
    {
       // facade.PlayNormalSound(AudioManager.Sound_ButtonClick);
    }

    /// <summary>
    /// 界面被显示出来
    /// </summary>
    public virtual void OnEnter()
    {
        gameObject.SetActive(true);
    }
    public virtual void OnExit()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 界面暂停
    /// </summary>
    public virtual void OnPause()
    {

    }

    /// <summary>
    /// 界面继续
    /// </summary>
    public virtual void OnResume()
    {

    }
    
    public virtual void OnCloseClick()
    {
        uiMng.PopPanel();
    }
}
