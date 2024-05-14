using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RequireComponent�Ő�΂�rigidbody�𓾂�
[RequireComponent(typeof(Rigidbody))]

public class Jump : MonoBehaviour
{
    [Header("�W�����v�̍ő呬�x�Ɨ����̍ő呬�x")]
    [SerializeField] private float maxJumpSpeedY = 13.0f;
    [SerializeField] private float maxFallSpeedY = 13.0f;
    [Header("�W�����v���̍ŏ��̑���")]
    [SerializeField] private float StartAccelY = 5.0f;
    float AccelY = 0;
    public bool isJumping { get; private set; }

    [Header("�W�����v�̍ō����B�_�i�����ɂ͈Ⴄ�j")]
    [SerializeField] float maxHeight = 4.0f;
    float jumpPos = 0.0f;

    //�W�����v����
    Vector3 jumpForward = new Vector3(0.0f, 1.0f, 0.0f);

    //------------------------------------------------
    //�L�����N�^�[�̃��W�b�h�{�f�B
    //------------------------------------------------
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartJump()    //�W�����v�J�n�֐�
    {
        isJumping = true;
        AccelY = StartAccelY;
        jumpPos = transform.position.y;
    }
    public void QuitJump()
    {
        isJumping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb == null) return;

        if (isJumping)
        {
            //�����Ȃ�΂Ȃ�قǗ͂��キ�Ȃ鎮
            AccelY = ((jumpPos + maxHeight) - transform.position.y + 2) * StartAccelY;
            //��x�c�̑������O��
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(jumpForward * AccelY, ForceMode.Impulse);


            //���������߂�������艺�̏ꍇ�@�W�����v���p��
            if (transform.position.y - jumpPos < maxHeight)
            {
                //�܂�A�����ɂ́A�V�䂪�Ȃ���΍ő�̍����܂ŏ㏸���Ȃ����
            }
            else
            {
                isJumping = false;
            }
        }
        else
        {
            //�W�����v���Ă��Ȃ��Ȃ�A�ŏ��̗͂����Z�b�g
            if (StartAccelY != AccelY)
            {
                AccelY = StartAccelY;
            }
        }

        //�ő�X�s�[�h�𒴂��Ȃ��悤�ɂ���
        if (rb.velocity.y >= maxJumpSpeedY)//��
        {
            rb.velocity = new Vector3(rb.velocity.x, maxJumpSpeedY,rb.velocity.z);
        }
        else if (rb.velocity.y <= -maxFallSpeedY)//��
        {
            rb.velocity = new Vector3(rb.velocity.x, -maxFallSpeedY, rb.velocity.z);
        }
    }
}
