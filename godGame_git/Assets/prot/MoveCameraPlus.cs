using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraPlus : MonoBehaviour
{
    [Header("キャラクターオブジェクトの名前")]
    public string charaName = "Toko_win";//キャラクターのオブジェクト名
    [Header("キャラクターとカメラの距離")]
    public float kyori = 3.0f; //キャラクターとカメラの距離
    [Header("マウス設定")]
    public float kando = 500.0f; //感度
    public bool reverseFg; //上下方向の操作を反転する場合、エディタでチェックを入れる

    GameObject charaObj; //キャラクターオブジェクト
    Vector3 cameraVec; //カメラの位置
    Vector3 targetPos; //注視点の位置

    float mouseInputX;
    float mouseInputY;

    int wait = 100;

    void Start()
    {
        //名前検索でScene中からオブジェクトを見つける
        charaObj = GameObject.Find(charaName);
        cameraVec = new Vector3(0.0f, 0.0f, 0.0f);

        //カメラの注視点を決める（キャラクターの少し上）
        targetPos = ExportTargetPos(charaObj); //キャラクターの座標を取得

        //カメラの位置を決める（キャラクタの後ろ方向へkyoriだけ移動させた地点）
        Vector3 k = charaObj.transform.forward; //キャラクターの正面方向のベクトルを取得
        k = k * -1; //-1を掛けてキャラクターの真後ろ方向のベクトルにする
        k = k.normalized * kyori;//normalizedで最大値を±1にしてから、ベクトルの長さをkyoriにする
        this.transform.position = targetPos + k; //カメラの位置を決定する

        //カメラを注視点へ向ける
        this.transform.LookAt(targetPos);
    }


    void Update()
    {
        //最初の100フレームは操作できないようにする
        if (wait > 0)
        {
            wait--;
            return;
        }

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");

        //キャラクターが移動していたら
        Vector3 tpos = ExportTargetPos(charaObj);
        if (tpos != targetPos)
        {
            //移動差を取得
            Vector3 sa = targetPos - tpos;

            //カメラの位置も同じだけ動かす
            this.transform.position -= sa;

            //カメラの注視点を更新
            targetPos = tpos;
        }

        //Y軸を中心にカメラを左右に見回す
        if (reverseFg == true) { mouseInputY *= -1; } //もしrebirthFgが立っていれば反転させる
        this.transform.RotateAround(targetPos, charaObj.transform.up, mouseInputX * kando * Time.deltaTime);

        //X軸を中心にカメラを上下に見回す
        Vector3 backupPos = this.transform.position;
        Vector3 backupAngle = this.transform.eulerAngles;
        this.transform.RotateAround(targetPos, charaObj.transform.right, mouseInputY * kando * Time.deltaTime);
        if (this.transform.eulerAngles.x > 45 && this.transform.eulerAngles.x < 90) //もし45°以上傾けたらそれ以上傾かないようにする
        {
            this.transform.position = backupPos;
            this.transform.eulerAngles = backupAngle;
        }
        else if (this.transform.eulerAngles.x > 270 && this.transform.eulerAngles.x < 315) //もし45°以上傾けたらそれ以上傾かないようにする
        {
            this.transform.position = backupPos;
            this.transform.eulerAngles = backupAngle;
        }

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, charaObj.transform.eulerAngles.z);

        //キャラクターもカメラに背を向けるように回転させる！！
        Vector3 k = this.transform.eulerAngles;
        charaObj.transform.eulerAngles = new Vector3(charaObj.transform.eulerAngles.x, k.y, charaObj.transform.eulerAngles.z);
    }

    void FixedUpdate()
    {

    }

    Vector3 ExportTargetPos(GameObject obj)
    {
        Vector3 res;
        res.x = obj.transform.position.x;
        res.y = obj.transform.position.y + 1.0f;//少し上にする
        res.z = obj.transform.position.z;

        res += obj.transform.right * 0.7f; //真正面が見えるように、少しキャラクターの右に寄せる
        return res;
    }

}
