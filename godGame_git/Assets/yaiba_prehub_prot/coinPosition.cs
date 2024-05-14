using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPosition : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Y���W��Cube�i�v���[���[�j�̒��S�ɂȂ�悤��
                transform.position = new Vector3(hit.point.x, 1.0f, hit.point.z);
            }
        }
    }
}
