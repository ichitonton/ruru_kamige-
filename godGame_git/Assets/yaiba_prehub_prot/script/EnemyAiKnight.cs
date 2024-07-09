using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyAiKnight : MonoBehaviour
{
    public GameObject searchRange;
    public float moveSpeed;

    float time;
    float sTime;
    bool move;
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

            //�G�����m�I
            if (serch.GetDetection())
            {
                move = true;
            }

            if (!move)
            {
                dis = new Vector3(0.0f, 0.0f, 0.0f);
                velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }

            if (move)
            {
                sTime += 0.1f;
                //�^�[�Q�b�g������
                Debug.Log("�^�[�Q�b�g������");
                Vector3 tarPos = serch.getSerchTarget().transform.position;
                tarPos.y = this.transform.position.y;
                this.transform.LookAt(tarPos);

                dis = serch.getSerchTarget().transform.position - this.transform.position;
                dis = dis.normalized;//���K��

                //if (sTime >= 3.0f)
                //{
                //    move = false;
                //    dis = new Vector3(0.0f, 0.0f, 0.0f);
                //    velocity = new Vector3(0.0f, 0.0f, 0.0f);
                //    sTime = 0.0f;
                //}
                //else if (sTime >= 2.2f)
                //{
                //    velocity *= 0.7f;
                //}
                //else if (sTime >= 2.0f)
                //{
                //    Debug.Log("�ːi�I");
                    velocity.x = dis.x * moveSpeed;
                    velocity.z = dis.z * moveSpeed;
                //}
                move = false;
            }
        }
        //rb.transform.position += velocity * 0.01f;
        //rb.GetPointVelocity();
        rb.AddForce(velocity * 1.0f, ForceMode.Force);

    }
}
