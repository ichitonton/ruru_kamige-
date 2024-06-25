using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Timeline;

public class AiDogEnemy : MonoBehaviour
{
    public GameObject searchRange;
    public float moveSpeed;

    float time;
    float sTime;
    bool rush;
    int mode;
    Serch serch;

    Rigidbody rb;
    //public GameObject[] objects = new GameObject[10];
    Vector3 dis;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0.0f;
        dis = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        serch = searchRange.GetComponent<Serch>();
        if (time >= 0.1f)
        {
            time = 0.0f;

            //敵を検知！
            if (serch.GetDetection())
            {
                rush = true;
            }

            if (rush)
            {
                sTime += 0.1f;
                //ターゲットを向く
                if (sTime <= 1.0f)
                {
                    Debug.Log("ターゲットを向く");

                    Vector3 tarPos = serch.getSerchTarget().transform.position;
                    tarPos.y = this.transform.position.y;

                    this.transform.LookAt(tarPos);
                    dis = serch.getSerchTarget().transform.position - this.transform.position;
                    dis = dis.normalized;//正規化
                }

                if (sTime >= 3.0f)
                {
                    rush = false;
                    dis = new Vector3(0.0f, 0.0f, 0.0f);
                    velocity = new Vector3(0.0f, 0.0f, 0.0f);
                    sTime = 0.0f;
                }
                else if (sTime >= 2.2f)
                {
                    velocity *= 0.7f;
                }
                else if (sTime >= 2.0f)
                {
                    Debug.Log("突進！");
                    velocity.x = dis.x * moveSpeed;
                    velocity.z = dis.z * moveSpeed;
                }

            }
        }
        //rb.transform.position += velocity * 0.01f;
        rb.AddForce(velocity * 0.05f, ForceMode.Impulse);
    }
}
