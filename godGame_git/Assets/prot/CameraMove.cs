using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class CameraMove : MonoBehaviour
{
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

    private Vector3 targetPos;          // 注視点の位置

    Rigidbody rb;

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

        print(transform.eulerAngles.x);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("RightStickX");
        float inputY = Input.GetAxis("RightStickY");

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
    }

    private Vector3 ExportTargetPos(GameObject obj)
    {
        Vector3 res;
        res.x = obj.transform.position.x;
        res.y = obj.transform.position.y + 1.0f;//少し上にする
        res.z = obj.transform.position.z;

        //res += obj.transform.right * 0.7f; //真正面が見えるように、少しキャラクターの右に寄せる
        return res;
    }

    public void Reset()
    {
        //カメラの注視点を決める（キャラクターの少し上）
        targetPos = ExportTargetPos(player); //キャラクターの座標を取得

        //カメラの位置を決める（キャラクタの後ろ方向へdistanceだけ移動させた地点）
        Vector3 k = new Vector3(rb.velocity.x, 0, rb.velocity.z); //キャラクターの正面方向のベクトルを取得

        if ((k.x == Vector3.zero.x) && (k.z == Vector3.zero.z))
        {

            k = player.transform.forward; //キャラクターの正面方向のベクトルを取得
            k = k * -1; //-1を掛けてキャラクターの真後ろ方向のベクトルにする
            k = k.normalized * distance;//normalizedで最大値を±1にしてから、ベクトルの長さをdistanceにする
            this.transform.position = targetPos + k; //カメラの位置を決定する

            //カメラを注視点へ向ける
            this.transform.LookAt(targetPos);

            print("入力無し");
        }
        else
        {
            k = k * -1; //-1を掛けてキャラクターの真後ろ方向のベクトルにする
            k = k.normalized * distance;//normalizedで最大値を±1にしてから、ベクトルの長さをdistanceにする
            this.transform.position = targetPos + k; //カメラの位置を決定する

            //カメラを注視点へ向ける
            this.transform.LookAt(targetPos);

            print("入力あり");
        }
    }
}
