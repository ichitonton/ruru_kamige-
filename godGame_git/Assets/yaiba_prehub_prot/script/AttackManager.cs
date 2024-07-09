using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public float attackPower;
    public float chargeGage;
    public string tagPlayer;
    public string tagTarget;
    public bool isHitDestroy = true;
    public GameObject destroyObj;
    public bool isHitContinuity = false;
    public bool gage;//�Q�[�W�̊T�O�����邩�ǂ���
    bool oldHit = false;
    GameObject player;

    [SerializeField] public TagField tagField;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find(tagPlayer);
        if (!GameObject.Find(tagPlayer))
        {
            //Debug.Log("���̃^�O�̃I�u�W�F�N�g��������܂���ł����F" + tagTarget);
        }
        else
        {
        }
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
                Debug.Log("���̃^�O�̃I�u�W�F�N�g�Ƀq�b�g�F" + tagTarget);

                //�U�����q�b�g�����Ƃ��Ƀ`���[�W�𗭂߂�
                if (gage)
                {
                    player = GameObject.Find(tagPlayer);
                    chargeManager charge = player.GetComponent<chargeManager>();
                    charge.TakeCharge(chargeGage);
                }

                //�U�����q�b�g�����Ƃ��ɏ���
                if (isHitDestroy)
                {
                    if (isHitDestroy)
                    {
                        Debug.Log("destroy");
                        Destroy(destroyObj);
                    }
                }
                oldHit = true;
            }
        }
    }
}
