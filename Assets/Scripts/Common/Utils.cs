using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Utils
{
    private static Dictionary<string, GameObject> m_objDic = new Dictionary<string, GameObject>();

    public static GameObject LoadResource(string path)
    {
        //判断内存中是否已经有path路径下的资源，没有的话加载到内存  
        if (!m_objDic.ContainsKey(path))
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(path));
            m_objDic[path] = go;
        }
        if (m_objDic[path] == null)
        {
            return null;
        }
        return m_objDic[path];
    }

    public static GameObject CreateCharacter(string strPath, Transform partent, Vector3 pos)
    {
        GameObject go = Utils.LoadResource(strPath);
        if (!go.transform.parent)
        {
            go.transform.SetParent(partent, false);
            go.transform.localPosition = pos;
        }
        go.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        return go;
    }
}

