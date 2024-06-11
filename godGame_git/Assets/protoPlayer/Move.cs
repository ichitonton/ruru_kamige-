using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 moveValue;
    [Header("移動スピード")]
    public float Speed = 3.0f;
    [Header("ジャンプ力")]
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
        // ZLZRは押しっぱなしはいいがDownでとりたい場合は、フラグをとったりしないといけない
        // ===============================================================================================================

        // ===============================================================================================================
        // キーの設定は　https://unity-beginners-blog.unity3d.jp/2017/07/04/gamepad/　を参照
        // ===============================================================================================================

        // ===============================================================================================================
        // 動いている向きに回転させたい
        // https://metarabi.blog.jp/archives/22253707.html
        // 明日やる
        // ===============================================================================================================

        //Vector3 diff = transform.position - oldPos;   //前回からどこに進んだかをベクトルで取得
        //diff.y = 0;
        //oldPos = transform.position;  //前回のPositionの更新

        ////ベクトルの大きさが0.01以上の時に向きを変える処理をする
        //if (diff.magnitude > 0.1f)
        //{
        //    transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
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
        // キャラの移動　この方がよさそう
        rb.velocity = new Vector3(proto.x, rb.velocity.y, proto.z);
    }
}
