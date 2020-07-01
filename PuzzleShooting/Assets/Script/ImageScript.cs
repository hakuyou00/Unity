﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ImageScript : MonoBehaviour
{
    //識別用の番号
    public int Num;

    //オブジェクトが光ってるかどうか、光ってたら１、光ってなかったら０
    [NonSerialized]
    public int islight = 0;
    //個体番号
    public int originalNum;

    //PanelControllerオブジェクト、終了時に使用
    PanelController _panelController;

    //
    Recovery _recovery;

    void Start()
    {
        _panelController = GameObject.Find("PanelController").GetComponent<PanelController>();
        _recovery = GameObject.Find("Recovery(Clone)").GetComponent<Recovery>();
        if (Num == 0) islight = 1;
    }
    
    void Update()
    {
        //オブジェクトを消してスキルの終了
        if(!_panelController.isSkill)
        {
            Destroy(this.gameObject);
        }
        //Debug用。Escapeキーを押すとスキルの終了
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _panelController.isSkill = false;
        }
        if(Num == 5 && islight == 1)
        {
            Debug.Log("Skill Succese");
            _panelController.isSkill = false;
        }

        Light(islight);
    }
    //Imageをクリックした時の処理
    public void Click()
    {
        //startとendは回転しないようにする
        if (Num != 0 && Num != 5)
        {
            //クリック毎に時計回りに90°回転
            Quaternion q = Quaternion.Euler(0 , 0 , -90f);
            this.transform.rotation *= q;

            _recovery.TurnImage(originalNum);
        }
    }
    public void Light(int isLight)
    {
        //start以外光らせる
        if (Num != 0)
        {
            if (isLight == 1)
            {
                string s = this.name.Split('(')[0];
                var sprite = Resources.Load<Sprite>(@"Image/Recovery/" + s + "_light");
                this.GetComponent<Image>().sprite = sprite;
            }
            else
            {
                string s = this.name.Split('(')[0];
                var sprite = Resources.Load<Sprite>(@"Image/Recovery/" + s);
                this.GetComponent<Image>().sprite = sprite;
            }
        }
    }
}
