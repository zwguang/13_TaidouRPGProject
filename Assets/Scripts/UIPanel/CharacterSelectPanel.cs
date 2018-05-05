using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectPanel : BasePanel {
    private Button m_selectBtn;
    private Button m_startBtn;
    private GameObject m_currentModel = null;
    private Vector3 V_CHARACTER_POS = new Vector3(-182f, -157.8f, -164f);

    private Dictionary<E_CHARACTER_TYPE, string> m_pathDic = new Dictionary<E_CHARACTER_TYPE, string>();

    void Start () {
        m_pathDic.Add(E_CHARACTER_TYPE.BOY, "Prefabs/Boy");
        m_pathDic.Add(E_CHARACTER_TYPE.GIRL, "Prefabs/Girl");
        string path;
        m_pathDic.TryGetValue(E_CHARACTER_TYPE.BOY, out path);
        m_currentModel = Utils.CreateCharacter(path, transform, V_CHARACTER_POS);

        transform.Find("Btn_select").GetComponent<Button>().onClick.AddListener(OnSelectClick);
        transform.Find("Btn_start").GetComponent<Button>().onClick.AddListener(OnStartClick);
    }

    public void ShowCharacterModel(E_CHARACTER_TYPE type)
    {
        string path;
        m_pathDic.TryGetValue(type, out path);

        m_currentModel.SetActive(false);
        m_currentModel = Utils.CreateCharacter(path, transform, V_CHARACTER_POS);
        m_currentModel.SetActive(true);
    }

    void OnSelectClick()
    {
        uiMng.PushPanel(UIPanelType.CharacterShow);
    }

    void OnStartClick()
    {
        
    }

    public void SelectedType(E_CHARACTER_TYPE type)
    {
        switch (type)
        {
            case E_CHARACTER_TYPE.BOYSHOW:
                ShowCharacterModel(E_CHARACTER_TYPE.BOY);
                break;
            case E_CHARACTER_TYPE.GIRLSHOW:
                ShowCharacterModel(E_CHARACTER_TYPE.GIRL);
                break;
        }
    }
}
