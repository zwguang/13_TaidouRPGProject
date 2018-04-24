using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GamePanel : BasePanel {

    private Text timer;
    private int time = -1;
    private Button successBtn;
    private Button failBtn;
    private Button exitBtn;
    
    private void Start()
    {

    }
    public override void OnEnter()
    {
        gameObject.SetActive(true);
    }
    public override void OnExit()
    {

    }
}
