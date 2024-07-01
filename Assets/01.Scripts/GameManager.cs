using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject game_StartLine;

    [SerializeField] private GameObject game_Tower;
    [SerializeField] private GameObject game_Tower_Parent;
    
    [SerializeField] private GameObject game_Mob;
    [SerializeField] private GameObject game_Mob_Parent;


    //스테이지를 시작할때 설정해줘야하는 변수
    public int game_Stage = 0;

    public int game_Tower_CreatedCount = 0;
    public int game_Tower_LimitCount;

    public int game_Mob_CreatedCount = 0;
    public int game_Mob_Count;
    public float game_Mob_CreateSpeed;
    public float game_Mob_Speed;


    private void Start()
    {
        Method_Init();
    }

    //초기화
    public void Method_Init() {
        game_Tower_LimitCount = game_Tower_Parent.transform.childCount;
        Onclick_Btn_Start();
    }

    //스테이지 시작
    public void Onclick_Btn_Start()
    {
        InvokeRepeating("Method_MobCreate", 5f, game_Mob_CreateSpeed);
    }

    //타워 지정 위치에 랜덤 생성
    public void Onclick_Btn_CreateTower()
    {
        if (game_Tower_LimitCount > game_Tower_CreatedCount)
        {
            int rand = Random.Range(0, game_Tower_Parent.transform.childCount);

            if (game_Tower_Parent.transform.GetChild(rand).transform.childCount == 0)
            {
                GameObject ins = Instantiate(game_Tower, game_Tower_Parent.transform.GetChild(rand).transform.position, Quaternion.Euler(Vector3.zero));
                ins.transform.SetParent(game_Tower_Parent.transform.GetChild(rand));
                game_Tower_CreatedCount++;
            }
            else
            {
                Onclick_Btn_CreateTower();
            }
        }
    }

    //몹생성, 몹속도지정 
    public void Method_MobCreate()
    {
        GameObject ins = Instantiate(game_Mob, game_StartLine.transform.position, Quaternion.Euler(Vector3.zero));
        ins.transform.parent = game_Mob_Parent.transform;

        game_Mob.GetComponent<MobManager>().mob_Speed = game_Mob_Speed/20;
        game_Mob_CreatedCount++;
        //스테이지 갯수만큼 몹이 생성되면 정지
        if (game_Mob_CreatedCount == game_Mob_Count) {
            CancelInvoke();
        }
    }
}
