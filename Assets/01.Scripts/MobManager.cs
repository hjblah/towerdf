using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    //움직임 변수
    private GameObject mob_wayPoints_Parent;
    private GameObject[] mob_wayPoints = new GameObject[12];
    private int mob_currentPoint = 0;
    
    //몹이 가지는 변수, GameManager에서 아래 변수들 설정   
    public float mob_Speed = 0;
    public float mob_Hp = 100;
    void Start()
    {
        mob_wayPoints_Parent = GameObject.FindWithTag("Mob_WayPoint").gameObject;

        for (int i = 0; i < mob_wayPoints_Parent.transform.childCount; i++) {
            mob_wayPoints[i] = mob_wayPoints_Parent.transform.GetChild(i).gameObject;
        }

        transform.GetChild(0).GetComponent<Animator>().SetBool("Walk", true); // 테스트용 
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mob_wayPoints[mob_currentPoint].transform.position, mob_Speed);

        if (Vector2.Distance(transform.position, mob_wayPoints[mob_currentPoint].transform.position) < 0.1f){
            //몹 처다보는 방향
            if (mob_currentPoint == 1 ||  mob_currentPoint == 5 ||  mob_currentPoint == 9)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            if (mob_currentPoint == 3 || mob_currentPoint == 7)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            mob_currentPoint++;
            if (mob_wayPoints.Length == mob_currentPoint) { Destroy(gameObject); }
        }

        if (mob_Hp <= 0)
        {
            transform.GetComponentInChildren<Animator>().SetBool("Die", true);
            mob_Speed = 0;
            Destroy(gameObject, 1f);
        }
    }
}
