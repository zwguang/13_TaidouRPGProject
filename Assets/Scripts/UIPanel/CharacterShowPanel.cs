using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterShowPanel : BasePanel {
    private GameObject m_currentModel = null;
    private E_CHARACTER_TYPE m_type;
    private Vector3 V_CHARACTER_POS = new Vector3(0, -152, -172);


    private Dictionary<E_CHARACTER_TYPE, string> m_pathDic = new Dictionary<E_CHARACTER_TYPE, string>();
    void Start ()
    {
        Debug.Log("CharacterShowPanel Start");
        m_pathDic.Add(E_CHARACTER_TYPE.BOYSHOW, "Prefabs/BoyShow");
        m_pathDic.Add(E_CHARACTER_TYPE.GIRLSHOW, "Prefabs/GirlShow");

        string path;
        m_pathDic.TryGetValue(E_CHARACTER_TYPE.BOYSHOW, out path);
        m_currentModel = Utils.CreateCharacter("Prefabs/BoyShow", transform, V_CHARACTER_POS);

        transform.Find("Btn_return").GetComponent<Button>().onClick.AddListener(OnReturnClick);
        transform.Find("Btn_confirm").GetComponent<Button>().onClick.AddListener(OnConfirmClick);
    }
	
    public void ShowCharacterModel(E_CHARACTER_TYPE type)
    {
        string path;
        m_pathDic.TryGetValue(type, out path);
        m_currentModel.SetActive(false);
        m_currentModel = Utils.CreateCharacter(path, transform, V_CHARACTER_POS);
        m_currentModel.SetActive(true);
        m_type = type;
    }

    

    private void OnReturnClick()
    {
        uiMng.PopPanel();
    }
    private void OnConfirmClick()
    {
        uiMng.SelectedType(m_type);
        uiMng.PopPanel();
    }
}
