using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterPlus : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;

    Vector3 moveForward; //移動度
    Vector3 jumpForward; //移動度（ジャンプ）
    GameObject cameraObj;

    [Header("カメラオブジェクト名")]
    public string cameraName = "Main Camera"; //カメラオブジェクト名
    [Header("移動速度・ジャンプ力")]
    public float speed = 1000.0f; //移動速度
    public float maxSpeed = 100.0f; //最高速度
    public float jumpPower = 5.0f; //ジャンプ力
    public KeyCode jumpKey = KeyCode.Space; //ジャンプキー

    bool touchFg;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>(); //Rigidbodyコンポーネントを取得する
        anim = this.GetComponent<Animator>();//Animatorコンポーネントを取得する
        cameraObj = GameObject.Find(cameraName);　//カメラオブジェクトを見つけておく

        //カーソル表示・非表示
        Cursor.visible = false;
        //カーソルのロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //移動道をリセットする
        moveForward = Vector3.zero;
        jumpForward = Vector3.zero;

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        //カメラの方向ベクトルから、Yをゼロにすることで、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(cameraObj.transform.forward, new Vector3(1, 0, 1)).normalized;

        //キー入力値とカメラの向きから、移動方向を決定
        moveForward = cameraForward * inputY + cameraObj.transform.right * inputX;

        //接地判定用の球体の、
        //中心位置を足元から10センチ上にする
        Vector3 center = transform.position + Vector3.up * 0.10f;
        //半径も設定
        float radius = 0.14f;
        //判定対象を、Groundレイヤーのオブジェクトのみにしぼる
        LayerMask layer = LayerMask.GetMask("Ground");

        //球体にGroundレイヤーのオブジェクトが重なったらisGroundフラグをtrueにする
        bool isGround = Physics.CheckSphere(center, radius, layer);

        //ジャンプ処理
        if (isGround && Input.GetKeyDown(jumpKey))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z); //y方向の移動度をリセットする
            rb.AddForce(new Vector3(0.0f, jumpPower, 0.0f), ForceMode.Impulse); //上方向にAddForceする

            anim.SetBool("jumping", true); //ジャンプアニメオン
        }
        else
        {
            anim.SetBool("jumping", false); //ジャンプアニメオフ
        }

        //歩行アニメ
        if (moveForward != Vector3.zero)
        {
            anim.SetBool("running", true); //ランアニメオン
        }
        else
        {
            anim.SetBool("running", false); //ランアニメオフ
        }

        //移動度に移動速度を掛けて力を加える
        moveForward *= speed * Time.deltaTime;
        rb.velocity = new Vector3(moveForward.x, rb.velocity.y, moveForward.z); //XとZ方向に移動度を適用させる
        //rb.AddForce(moveForward, ForceMode.Force); //この方法でもOK

        //最高速度制限をかける
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void FixedUpdate()
    {

    }
}
