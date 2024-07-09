using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // 角度-になってるからそれを対処すれば出来そう
    [SerializeField] GameObject resetTarget;

    [Header("プレイヤーを設定 hierarchyからドラッグ&ドロップ")]
    public GameObject player;
    [Header("キャラクターとカメラの距離")]
    public float distance = 3.0f;              // カメラの距離
    [Header("カメラ感度 横")]
    public float sensitivityX = 300.0f;         // カメラ感度
    [Header("カメラ感度 縦")]
    public float sensitivityY = 300.0f;         // カメラ感度
    [Header("上下反転")]
    public bool reverseYFg = false;            //上下方向の操作を反転する場合、エディタでチェックを入れる
    [Header("左右反転")]
    public bool reverseXFg = false;            //左右方向の操作を反転する場合、エディタでチェックを入れる



    private Vector3 cameraPos;          // カメラの位置
    private Vector3 targetPos;          // 注視点の位置

    private bool reset;

    Rigidbody rb;

    private float resetAngleY;
    private float resetAngleX;

    private int count = 0;

    [SerializeField, Header("カメラリセットカウント")] int resetCount = 10;

    private float resetRato;

    // Start is called before the first frame update
    void Start()
    {
        //カメラの注視点を決める（キャラクターの少し上）
        targetPos = ExportTargetPos(player); //キャラクターの座標を取得

        //カメラの位置を決める（キャラクタの後ろ方向へdistanceだけ移動させた地点）
        Vector3 k = player.transform.forward; //キャラクターの正面方向のベクトルを取得
        k = k * -1; //-1を掛けてキャラクターの真後ろ方向のベクトルにする
        k = k.normalized * distance;//normalizedで最大値を±1にしてから、ベクトルの長さをdistanceにする
        this.transform.position = targetPos + k; //カメラの位置を決定する

        //カメラを注視点へ向ける
        this.transform.LookAt(targetPos);

        rb = player.GetComponent<Rigidbody>();

        reset = false;

        resetAngleY = 0;

        resetRato = (1.0f / resetCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            // もうちょっと回転抑えたいよね
            transform.RotateAround(targetPos, player.transform.up, resetAngleY);
            transform.RotateAround(targetPos, transform.right, resetAngleX);
            ++count;
            if (count == resetCount)
            {
                reset = false;
                count = 0;
            }
        }

        else 
        {
            float inputX = Input.GetAxis("RightStickX");
            float inputY = Input.GetAxis("RightStickY");

            if (reverseXFg) inputX *= -1; //もしrebirthFgが立っていれば反転させる
            if (reverseYFg) inputY *= -1; //もしrebirthFgが立っていれば反転させる

            if (transform.eulerAngles.x - 180.0f > 0)
            {
                if (inputY < 0f)
                    inputY = 0;
            }
            else if (transform.eulerAngles.x > 71)
                if (inputY > 0f)
                    inputY = 0;

            transform.RotateAround(targetPos, player.transform.up, inputX * sensitivityX * Time.deltaTime);
            transform.RotateAround(targetPos, transform.right, inputY * sensitivityY * Time.deltaTime);

            if (Input.GetButtonDown("L"))
            {
                SetCameraReset();
            }
        }
    }

    private void FixedUpdate()
    {
        //キャラクターが移動していたら
        Vector3 tpos = ExportTargetPos(player);
        if (tpos != targetPos)
        {
            //移動差を取得
            Vector3 sa = targetPos - tpos;

            //カメラの位置も同じだけ動かす
            this.transform.position -= sa;

            //カメラの注視点を更新
            targetPos = tpos;
        }
    }

    private Vector3 ExportTargetPos(GameObject obj)
    {
        Vector3 res;
        res.x = obj.transform.position.x;
        res.y = obj.transform.position.y + 2.0f;//少し上にする
        res.z = obj.transform.position.z;

        //res += obj.transform.right * 0.7f; //真正面が見えるように、少しキャラクターの右に寄せる
        return res;
    }

    public void SetCameraReset()
    {
        if (reset) return;

        reset = true;

        //カメラの位置を決める（キャラクタの後ろ方向へdistanceだけ移動させた地点
        Vector3 k = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if(k.sqrMagnitude == 0.0f) k = player.transform.forward;

        k = player.transform.forward; //キャラクターの正面方向のベクトルを取得
        k = k * -1; //-1を掛けてキャラクターの真後ろ方向のベクトルにする
        k = k.normalized * distance;//normalizedで最大値を±1にしてから、ベクトルの長さをdistanceにする
        resetTarget.transform.position = targetPos + k; //カメラの位置を決定する

        //カメラを注視点へ向ける
        resetTarget.transform.LookAt(targetPos);

        float targetAngle = resetTarget.transform.eulerAngles.y;
        float cameraAngle = transform.eulerAngles.y;

        resetAngleY = targetAngle - cameraAngle;

        resetAngleX = resetTarget.transform.eulerAngles.x - transform.eulerAngles.x;

        print(resetAngleY);

        if(resetAngleY < -180) resetAngleY += 360;
        else if(resetAngleY > 180) resetAngleY -= 360;

        resetAngleY *= resetRato;
        resetAngleX *= resetRato;
    }
}
