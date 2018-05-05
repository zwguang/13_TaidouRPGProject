using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


/// <summary>
/// 1.解析 UIPanelType.json 文件，获取面板的类型、prefab路径，存储在panelPathDict中
/// 2.通过prefab路径，加载prefab并获取身上的BasePanel组件，存储在 panelDict 中
/// 3.要显示某个面板，直接从panelDict获取，压入panelStack中
/// </summary>
public class UIManager: BaseManager
{
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;//存储所有面板Prefab的路径
    private Dictionary<UIPanelType, BasePanel> panelDict; //保存所有实例化面板的游戏物体身上的BasePanel组件
    private Stack<BasePanel> panelStack;
    private MessagePanel msgPanel;
    private UIPanelType panelTypeToPush = UIPanelType.None;
    public UIManager(GameFacade facade) : base(facade)
    {
        ParseUIPanelTypeJson();
    }

    public override void OnInit()
    {
        base.OnInit();
        PushPanel(UIPanelType.Message);
        PushPanel(UIPanelType.Start);
    }
    public override void Update()
    {
        if (panelTypeToPush != UIPanelType.None)
        {
            PushPanel(panelTypeToPush);
            panelTypeToPush = UIPanelType.None;
        }
    }

    public void PushPanelSync(UIPanelType panelType)
    {
        panelTypeToPush = panelType;
    }
    /// <summary>
    /// 把某个页面入栈，  显示
    /// </summary>
    public BasePanel PushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        //判断一下栈里面是否有页面
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
        return panel;
    }
    /// <summary>
    /// 出栈 ，把页面从界面上移除
    /// </summary>
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;

        //关闭栈顶页面的显示
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();

    }

    /// <summary>
    /// 根据面板类型 得到实例化的面板
    /// </summary>
    /// <returns></returns>
    private BasePanel GetPanel(UIPanelType panelType)
    {
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }
        
        BasePanel panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform,false);
            instPanel.GetComponent<BasePanel>().UIMng = this;
            instPanel.GetComponent<BasePanel>().Facade = facade;
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }

    }

    [Serializable]//接收json数据
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");//加载json文件

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);//反序列化

        foreach (UIPanelInfo info in jsonObject.infoList) 
        {
            //Debug.Log(info.panelType);
            panelPathDict.Add(info.panelType, info.path);
        }
    }


    public void InjectMsgPanel(MessagePanel msgPanel)
    {
        this.msgPanel = msgPanel;
    }
    public void ShowMessage(string msg)
    {
        if (msgPanel == null)
        {
            Debug.Log("无法显示提示信息，MsgPanel为空");return;
        }
        msgPanel.ShowMessage(msg);
    }
    public void ShowMessageSync(string msg)
    {
        if (msgPanel == null)
        {
            Debug.Log("无法显示提示信息，MsgPanel为空"); return;
        }
        msgPanel.ShowMessageSync(msg);
    }

    public void SetServer(string name, Color color)
    {
        StartPanel panel = GetPanel(UIPanelType.Start) as StartPanel;
        panel.SetServer(name, color);
    }

    public void SelectedType(E_CHARACTER_TYPE type)
    {
        CharacterSelectPanel panel = GetPanel(UIPanelType.CharacterSelect) as CharacterSelectPanel;
        panel.SelectedType(type);
    }
}
