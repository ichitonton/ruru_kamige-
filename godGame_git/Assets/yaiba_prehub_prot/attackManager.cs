using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackManager : MonoBehaviour
{
    public float attackPower;
    public string tagTarget;
    public bool isHitDestroy = true;
    public bool isHitContinuity = false;
    bool oldHit = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag(tagTarget))
        {
            Debug.Log("���̃^�O�̃I�u�W�F�N�g��������܂���ł����F" + tagTarget);
        }
        else if (other.CompareTag(tagTarget))
        {
            //�A���I�ɍU�������^����||���߂Ẵq�b�g
            if (oldHit && isHitContinuity || !oldHit)
            {
                //�U������
                hpManager target = other.GetComponent<hpManager>();
                target.TakeDamage(attackPower);
                //�U�����q�b�g�����Ƃ��ɏ���
                if (isHitDestroy)
                {
                    if (isHitDestroy)
                    {
                        Destroy(gameObject);
                    }
                }
                oldHit = true;
            }
        }
    }
}
