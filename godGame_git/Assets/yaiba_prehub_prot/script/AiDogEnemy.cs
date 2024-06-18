using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Timeline;

public class AiDogEnemy : MonoBehaviour
{
    public GameObject searchRange;
    float time;
    //public GameObject[] objects = new GameObject[10];
    Vector3 dis;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        dis = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Serch serch = searchRange.GetComponent<Serch>();

        //敵を検知！
        if (time > 0.5f)
        {
            time = 0.0f;
            Debug.Log("検知チェック");
            if (serch.GetDetection())
            {
                Debug.Log("GetDetection() = ture");
                if (serch.getSerchTarget() != null)
                {
                    Debug.Log("オブジェクトに移動！");
                    dis = serch.getSerchTarget().transform.position - this.transform.position;
                    dis = dis.normalized;//正規化

                }
            }
            else
            {
                dis = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
        this.transform.position += dis * 0.005f;
    }
}
