using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet_endPose;
    public float bullet_speed;
    public float bullet_power;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject == bullet_endPose) {
            collision.GetComponent<MobManager>().mob_Hp -= bullet_power; 
            Destroy(transform.gameObject);
        }
    }

    void Update()
    {
        try
        {
            transform.position = Vector2.MoveTowards(transform.position, bullet_endPose.transform.position, bullet_speed);
        }
        catch (Exception e)
        {
            Destroy(transform.gameObject);
            Debug.Log("몹이 먼저 사라짐");
        }
    }
}
