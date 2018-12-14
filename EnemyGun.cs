﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGo;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Girl");

        if(playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGo);
            bullet.transform.position = transform.position;
            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
