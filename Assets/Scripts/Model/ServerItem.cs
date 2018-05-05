using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerItem : MonoBehaviour {

    private string m_name;
    private string m_ip;
    private int m_count;

    private Text m_text;
    private Image m_image;
    private ServerPanel m_serverPanel;
    public ServerPanel serverPanel
    {
        set
        {
            m_serverPanel = value;   
        }
    }


    private const string C_SERVER_RED = "Textures/btn_1";
    private const string C_SERVER_GREEN = "Textures/btn_2";

    private void Awake()
    {
        m_text = transform.Find("Text").GetComponent<Text>();
        m_image = gameObject.GetComponent<Image>();
        gameObject.GetComponent<Button>().onClick.AddListener(OnServerClick);
    }

    private void OnServerClick()
    {
        m_serverPanel.SelectedServer(m_text, m_image);
    }
    

    public void SetProperty(string name, int count)
    {
        m_text.text = name;
        if(count > 50)
        {
            m_image.sprite = Resources.Load<Sprite>(C_SERVER_RED);
            m_text.color = Color.red;
        }
        else
        {
            m_text.color = Color.green;
            m_image.sprite = Resources.Load<Sprite>(C_SERVER_GREEN);
        }
    }

    public void SetProperty(Text name, Image image)
    {
        m_text.text = name.text;
        m_text.color = name.color;
        m_image.sprite = image.sprite;
    }
}
