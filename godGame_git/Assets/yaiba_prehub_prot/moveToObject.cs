using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class moveToObject : MonoBehaviour
{
    private GameObject target;
    private float speed = 3.0f;
    private Vector3 position;

    void Update()
    {
        position = target.transform.position;

        //スタート位置、ターゲットの座標、速度
        transform.position = Vector3.MoveTowards(
          transform.position,
          position,
          speed * Time.deltaTime);
    }
}
