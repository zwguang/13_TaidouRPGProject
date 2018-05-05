using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour {
    private Animator m_animator;
	// Use this for initialization
	void Start () {
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_animator.SetBool("bWalk", true);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            m_animator.SetBool("bRun", true);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            m_animator.Play("Stand");
        }
    }
}
