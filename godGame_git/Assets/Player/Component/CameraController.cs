using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;

    [SerializeField, Header("カメラの距離")] private float distance = 10.0f;

    [SerializeField, Header("カメラの感度　横")] public float sensitivityX = 300.0f;
    [SerializeField, Header("カメラの感度　縦")] public float sensitivityY = 200.0f;

    [SerializeField, Header("カメラの反転　横")] public bool inversionX = false;
    [SerializeField, Header("カメラの反転　縦")] public bool inversionY = false;

    [SerializeField, Header("カメラの可動角度　上")] public float cameraMaxAngleUp = 80.0f;
    [SerializeField, Header("カメラの可動角度　下")] public float cameraMaxAngleDown = 30.0f;
    private float cameraAngleDown;

    [SerializeField, Header("カメラのリセット時　高さも戻すか")] public bool cameraResetHeight = true;

    [SerializeField, Header("カメラのリセット時　スティックの方向に向くか\nプレイヤーの向きに向くか")] public bool cameraResetStickDirection = true;
    private Vector3 cameraResetDirection = Vector3.zero;

    [SerializeField, Header("デフォルトのカメラ角度")] public float defaultAngle = 30;

    [SerializeField, Header("カメラのリセットの速度")] private int resetCount = 40;

    [SerializeField, Header("地形オブジェクトのレイヤーを選択")] private LayerMask terrain;

    private float inputX = 0.0f;
    private float inputY = 0.0f;

    private bool reset = false;
    private float resetAngleX = 0.0f;
    private float resetAngleY = 0.0f;
    private float afterResetAngleY = 0.0f;
    private int frameCount = 0;

    private Vector3 direction;

    RaycastHit hit;


    bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        direction = Quaternion.AngleAxis(defaultAngle, camera.transform.right) * -transform.forward;

        cameraAngleDown = (360 - cameraMaxAngleDown);
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            direction = Quaternion.AngleAxis(resetAngleX, transform.up) * direction;
            if(cameraResetHeight) direction = Quaternion.AngleAxis(resetAngleY, camera.transform.right) * direction;
            ++frameCount;

            if (frameCount == resetCount)
            {
                reset = false;
                frameCount = 0;

                direction = Quaternion.AngleAxis(afterResetAngleY, camera.transform.right) * -transform.forward;
            }
        }
        else
        {
            direction = Quaternion.AngleAxis(inputX * sensitivityX * Time.deltaTime, transform.up) * direction;
            direction = Quaternion.AngleAxis(inputY * sensitivityY * Time.deltaTime, camera.transform.right) * direction;
        }

        isHit = Physics.SphereCast(
        transform.position + new Vector3(0,0.1f,0),                                 // 発射位置
        camera.transform.transform.lossyScale.x * 0.5f,                             // 大きさ　原点からの長さだから /2 しないといけない
        direction,                                                                  // 方向
        out hit,                                                                    // あたったものの情報を格納する
        distance,                                                                   // レイの長さ
        terrain
        );

        if (isHit)
        {
            if (hit.distance > 1)
                camera.transform.position = transform.position + (direction * hit.distance);
            else
                camera.transform.position = transform.position + (direction * 1);
        }
        else camera.transform.position = transform.position + (direction * distance);
        camera.transform.forward = -direction;
    }

    public void SetCameraMove(float iX, float iY)
    {
        inputX = iX;
        inputY = iY;

        if (inversionX) inputX *= (-1);
        if (inversionY) inputY *= (-1);

        if ((camera.transform.eulerAngles.x > 180))
        {
            if ((camera.transform.eulerAngles.x < cameraAngleDown))
            {
                if (inputY < 0f)
                    inputY = 0;
            }
        }
        else if (camera.transform.eulerAngles.x > cameraMaxAngleUp)
        {
            if (inputY > 0f)
                inputY = 0;
        }
        if (isHit)
        {
            if (hit.distance < 1)
            {
                if (inputY < 0f)
                    inputY = 0;
            }
        }
    }

    public void SetCameraReset()
    {
        reset = true;

        afterResetAngleY = cameraResetHeight ? 30 : camera.transform.eulerAngles.x;

        // 此処の挙動未確認
        Vector3 proto = Vector3.zero;
        if (cameraResetStickDirection)
        {
            Vector3 crd = new Vector3(cameraResetDirection.x, 0.0f, cameraResetDirection.z);
            if(crd == Vector3.zero)
                proto = Quaternion.AngleAxis(afterResetAngleY, camera.transform.right) * -transform.forward;
            else
                proto = Quaternion.AngleAxis(afterResetAngleY, camera.transform.right) * -cameraResetDirection;
        }
        else
            proto = Quaternion.AngleAxis(afterResetAngleY, camera.transform.right) * -transform.forward;

        resetAngleX = -PlaneAngle(proto, direction, transform.up);

        resetAngleX /= resetCount;

        resetAngleY = -PlaneAngle(proto, direction, camera.transform.right);

        if (resetAngleY > 90)
        {
            resetAngleY -= 180;
        }
        else if (resetAngleY < -90)
        {
            resetAngleY += 180;
        }

        resetAngleY /= resetCount;
    }

    private float PlaneAngle(Vector3 from, Vector3 to, Vector3 axis)
    {
        Vector3 planeNormal = axis;

        // 平面に投影されたベクトルを求める
        Vector3 planeFrom = Vector3.ProjectOnPlane(from, planeNormal);
        Vector3 planeTo = Vector3.ProjectOnPlane(to, planeNormal);

        // 平面に投影されたベクトル同士の符号付き角度
        // 時計回りで正、反時計回りで負
        float signedAngle = Vector3.SignedAngle(planeFrom, planeTo, planeNormal);

        return signedAngle;

    }

    public void SetResetDirection(Vector3 d)
    {
        cameraResetDirection = d;
    }
}
