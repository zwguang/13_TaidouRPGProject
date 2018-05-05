using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 点击头像时展示3d角色模型
/// </summary>
public class HeadImage : MonoBehaviour {
    public E_CHARACTER_TYPE m_type;
    public CharacterShowPanel m_characterShowPanel;

	void Start ()
    {
        Debug.Log("HeadImage Start");
        transform.GetComponent<Button>().onClick.AddListener(OnImageClick);
    }

    private void OnImageClick()
    {
        m_characterShowPanel.ShowCharacterModel(m_type);
    }
}
