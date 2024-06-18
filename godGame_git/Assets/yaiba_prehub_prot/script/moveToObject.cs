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

        //�X�^�[�g�ʒu�A�^�[�Q�b�g�̍��W�A���x
        transform.position = Vector3.MoveTowards(
          transform.position,
          position,
          speed * Time.deltaTime);
    }
}
