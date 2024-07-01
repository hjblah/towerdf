using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    [SerializeField] private RangeManager char_rangeManager;
    [SerializeField] private GameObject char_currentTarget;
    [SerializeField] private GameObject char_bullet;
    [SerializeField] private float char_bullet_power;
    [SerializeField] private float char_bullet_speed;
    [SerializeField] private float char_bullet_fireRate;

    private float char_bullet_currentfireRate;
    private bool char_shootFlag;

    // Start is called before the first frame update
    void Start()
    {
        char_rangeManager = transform.GetComponentInChildren<RangeManager>();
        char_bullet_currentfireRate = char_bullet_fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //범위 내 적이 들어왔을 때 
        if (char_rangeManager.range_Target_List.Count > 0)
        {
            transform.GetComponentInChildren<Animator>().SetBool("Attack", true);
            char_currentTarget = char_rangeManager.range_Target_List[0];

            char_shootFlag = true;
        }
        //범위 내에 적이 없을 때 
        else {
            transform.GetComponentInChildren<Animator>().SetBool("Attack", false);
            char_currentTarget = null;

            char_shootFlag = false;
        }


        if (char_shootFlag)
        {
            char_bullet_currentfireRate += Time.deltaTime;
            if (char_bullet_currentfireRate >= char_bullet_fireRate)
            {
                Method_BulletCreate();
                char_bullet_currentfireRate = 0;
            }
        }
    }

    public void Method_BulletCreate() {
        GameObject ins = Instantiate(char_bullet, transform.position, Quaternion.Euler(Vector3.zero));

        ins.GetComponent<BulletManager>().bullet_power = char_bullet_power;
        ins.GetComponent<BulletManager>().bullet_endPose = char_currentTarget;
        ins.GetComponent<BulletManager>().bullet_speed = char_bullet_speed;
    }
}
