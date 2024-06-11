using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveValue;
    [Header("�ړ��X�s�[�h")]
    public float Speed = 3.0f;
    [Header("�W�����v��")]
    public float JampForce = 3.0f;
    private float speedValue;

    private Vector3 direction;
    private Vector3 cameraForward;
    private GameObject cameraObject;

    private Vector3 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cameraObject = GameObject.Find("Main Camera");

        moveValue = new Vector3(0, 0, 0);
        if (Speed < 0) Speed = 0;

        speedValue = Speed;

    }

    void Update()
    {
        // ===============================================================================================================
        // if (Input.GetButtonDown("L")) print("L");
        // if (Input.GetButtonDown("R")) print("R");
        // if (((Input.GetAxis("ZR")) > 0)) print("ZR");
        // if (((Input.GetAxis("ZL")) > 0)) print("ZL");
        // ZLZR�͉������ςȂ��͂�����Down�łƂ肽���ꍇ�́A�t���O���Ƃ����肵�Ȃ��Ƃ����Ȃ�
        // ===============================================================================================================

        // ===============================================================================================================
        // �L�[�̐ݒ�́@https://unity-beginners-blog.unity3d.jp/2017/07/04/gamepad/�@���Q��
        // ===============================================================================================================

        // ===============================================================================================================
        // �����Ă�������ɉ�]��������
        // https://metarabi.blog.jp/archives/22253707.html
        // �������
        // ===============================================================================================================

        //Vector3 diff = transform.position - oldPos;   //�O�񂩂�ǂ��ɐi�񂾂����x�N�g���Ŏ擾
        //diff.y = 0;
        //oldPos = transform.position;  //�O���Position�̍X�V

        ////�x�N�g���̑傫����0.01�ȏ�̎��Ɍ�����ς��鏈��������
        //if (diff.magnitude > 0.1f)
        //{
        //    transform.rotation = Quaternion.LookRotation(diff); //������ύX����
        //}

        cameraForward = Vector3.Scale(cameraObject.transform.forward, new Vector3(1, 0, 1)).normalized;

        float vertical = Input.GetAxis("LeftStickY");
        float horizontal = Input.GetAxis("LeftStickX");

        //if (((vertical > 0.1f) || (vertical < (-0.1f))) || ((horizontal > 0.1f) || (horizontal < (-0.1f))))
        direction = cameraForward * vertical + cameraObject.transform.right * horizontal;
        //else direction = cameraForward * 0 + cameraObject.transform.right * 0;

        if (Input.GetButton("R")) Speed = speedValue * 1.5f;
        else if (Input.GetButtonUp("R")) Speed = speedValue;
    }

    void FixedUpdate()
    {
        Vector3 proto = direction * Speed;
        // �L�����̈ړ��@���̕����悳����
        rb.velocity = new Vector3(proto.x, rb.velocity.y, proto.z);
    }
}
