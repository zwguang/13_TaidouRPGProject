using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerPanel : BasePanel {
    public Transform m_parent;
    private GameObject m_selectedItem;

    private void Awake()
    {
        m_selectedItem = transform.Find("SelectedItem").gameObject;
        m_selectedItem.SetActive(false);
        m_selectedItem.GetComponent<Button>().enabled = false;
    }

    void Start ()
    {
        for (int i = 1; i < 20; i++)
        {
            CreateServer(i + "区 王者峡谷", Random.Range(0, 100));
        }
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    void CreateServer(string name, int count)
    {
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/Btn_server_red"));
        go.transform.SetParent(m_parent, false);
        ServerItem item = go.GetComponent<ServerItem>();
        item.serverPanel = this;
        item.SetProperty(name, count);
    }
    
    public void SelectedServer(Text name, Image image)
    {
        m_selectedItem.SetActive(true);
        m_selectedItem.GetComponent<ServerItem>().SetProperty(name, image);
        uiMng.SetServer(name.text, name.color);
        Invoke("OnCloseClick", 0.2f);
    }
}
