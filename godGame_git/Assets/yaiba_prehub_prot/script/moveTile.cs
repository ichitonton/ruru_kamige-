using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

public class moveTile : MonoBehaviour
{
    public Transform toMoveTarget;
    public float stayTime;
    public float moveTime;


    int moveMode = 0;
    float time;
    Vector3 vecZero = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 dis;
    Vector3 moveObjTrans;
    Vector3 targetObjTrans;
    Rigidbody tRb;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        dis = toMoveTarget.position - this.transform.position;
        moveObjTrans = this.transform.position;
        targetObjTrans = toMoveTarget.position;
        moveMode = 1;
        tRb = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //初期位置→ターゲットの位置
        if (moveMode == 1)
        {
            if (time <= moveTime)
            {
                tRb.MovePosition(moveObjTrans + dis * (time / moveTime));
            }
            else if (time > moveTime)
            {
                this.transform.position = targetObjTrans;
                tRb.velocity= vecZero;
                time = 0.0f;
                moveMode = 2;
            }
        }
        //ターゲットの位置で停止
        if (moveMode == 2)
        {
            if (time > stayTime)
            {
                time = 0.0f;
                moveMode = 3;
            }
        }
        //ターゲットの位置→初期位置
        if (moveMode == 3)
        {
            if (time <= moveTime)
            {
                tRb.MovePosition(targetObjTrans - dis * (time / moveTime));
            }
            else if (time > moveTime)
            {
                this.transform.position = moveObjTrans;
                tRb.velocity.Set(0.0f, 0.0f, 0.0f);
                time = 0.0f;
                moveMode = 4;
            }
        }
        //初期位置で停止
        if (moveMode == 4)
        {
            if (time > stayTime)
            {
                time = 0.0f;
                moveMode = 1;
            }
        }
    }
}

