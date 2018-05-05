using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CloudMove : MonoBehaviour {

    public Vector2 m_startPos;
    public Vector2 m_endPos;
    public float m_repeatTime;
    private Tweener m_tweener;
    // Use this for initialization
    void Start ()
    {
        InvokeRepeating("Move", 0, m_repeatTime);
        
    }

    private void Move()
    {
        m_tweener = transform.DOLocalMove(m_endPos, m_repeatTime/2).
            OnComplete(()=> {
                m_tweener.PlayBackwards();//倒放
            });
        m_tweener.SetEase(Ease.Linear);//设置移动类型
        m_tweener.SetUpdate(true);     //动画不受Time.scale影响
        m_tweener.SetAutoKill(false);  //动画不会自动销毁，才能倒放
    }
}
