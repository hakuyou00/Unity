﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    PlayerController _playerController;

    public float speed = 0.1f;
    public float damagePoint = 1.0f;
    float moveOverY;

    public bool isBoss = false;
    public bool isPlayer;

    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        moveOverY = (19.2f * ((float)Screen.height / (float)Screen.width)) + 1f;
    }

    void Update()
    {
        if(isPlayer)
        {
            this.transform.position += transform.up * speed * Time.deltaTime * 0.6f;
        }
        else
        {
            if(!isBoss) this.transform.position += transform.up * speed * Time.deltaTime * 0.3f;
        }

        if (this.transform.position.y >= moveOverY || this.transform.position.y <= -moveOverY || this.transform.position.x <= -13f || this.transform.position.x >= 13f)
        { 
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PLAYER" && !isPlayer)
        {
            //ここにプレイヤーが弾に当たった時の処理を書く
            //Debug.Log("Hit!");
            _playerController.health_Point -= 5f;
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "ENEMY" && isPlayer)
        {
            //Debug.Log("Hit");
            float defense = other.gameObject.GetComponent<Viran>().defensePoint;
            other.gameObject.GetComponent<Viran>().ViranHealth -= (damagePoint - defense);
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "BOSS" && isPlayer)
        {
            float defence = other.gameObject.GetComponent<Boss>().defensePoint;
            other.gameObject.GetComponent<Boss>().bossHealth -= (damagePoint - defence);
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "MIDBOSS" && isPlayer)
        {
            float defence = other.gameObject.GetComponent<MidBoss>().defencePoint;
            other.gameObject.GetComponent<MidBoss>().HealthPoint -= (damagePoint - defence);
            Destroy(this.gameObject);
        }
    }
}

