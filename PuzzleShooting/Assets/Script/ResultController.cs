﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{
    public AudioSource Player;

    public Text resultText;
    public Text Score;

    public static int score = 10000000;

    public static bool isClear = false;

    void Start()
    {
        SetUI();
    }

    void Update()
    {

    }
    public void BackSelect()
    {
        SceneManager.LoadScene("Select");
    }
    void SetUI()
    {
        Score.text = "Score:" + score.ToString();

        if(isClear)
        {
            resultText.text = "Stage Clear";
            resultText.color = Color.yellow;
        }
        else
        {
            resultText.text = "Stage Faild";
            resultText.color = Color.blue;
            Player.volume = SelectController.volume;
            Player.Play();
        }
    }
}