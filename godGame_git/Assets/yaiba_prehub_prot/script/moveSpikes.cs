using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class moveSpikes : MonoBehaviour
{

    public Transform parent;
    public float waitToAttackTime;
    public float attckStayTime;
    public float attackToWaitTime;
    public float waitStayTime;
    
    int moveMode = 0;
    float time;
    Vector3 vecZero = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 firstSpikeTrans;
    Vector3 endSpikeTrans;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        firstSpikeTrans = this.transform.localPosition;
        endSpikeTrans = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y + 0.9f, this.transform.localPosition.y);
        moveMode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //初期位置→ターゲットの位置
        if (moveMode == 1)
        {
            if (time <= waitToAttackTime)
            {
                this.transform.localPosition = firstSpikeTrans + endSpikeTrans * (time / waitToAttackTime);
            }
            else if (time > waitToAttackTime)
            {
                this.transform.localPosition = endSpikeTrans;
                time = 0.0f;
                moveMode = 2;
            }
        }
        //ターゲットの位置で停止
        if (moveMode == 2)
        {
            if (time > attckStayTime)
            {
                time = 0.0f;
                moveMode = 3;
            }
        }
        //ターゲットの位置→初期位置
        if (moveMode == 3)
        {
            if (time <= attackToWaitTime)
            {
                this.transform.localPosition = endSpikeTrans - endSpikeTrans * (time / attackToWaitTime);
            }
            else if (time > attackToWaitTime)
            {
                this.transform.localPosition = firstSpikeTrans;
                time = 0.0f;
                moveMode = 4;
            }
        }
        //初期位置で停止
        if (moveMode == 4)
        {
            if (time > waitStayTime)
            {
                time = 0.0f;
                moveMode = 1;
            }
        }
    }
}
