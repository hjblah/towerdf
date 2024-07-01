using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeManager : MonoBehaviour
{
    public List<GameObject> range_Target_List = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Mob"))
        {
            range_Target_List.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("Mob"))
        {
            range_Target_List.Remove(collision.gameObject);
        }
    }

    private void Update()
    {
        for (int i = 0; i < range_Target_List.Count; i++)
        {
            if (range_Target_List[i] == null)
            {
                range_Target_List.RemoveAt(i);
            }
        }
    }
}
