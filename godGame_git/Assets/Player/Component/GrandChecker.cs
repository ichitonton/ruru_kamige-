using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandChecker : MonoBehaviour
{
    // ===============================================
    // プレイヤーにしか使わんからprivateでいいかな
    // ===============================================

    //  CastRayの発生元を少し上にずらす距離
    [SerializeField, Header("CastRayの発生元を少し上にずらす距離")]
    const float epsilon = 0.005f;

    [SerializeField,Header("Colliderと地面の距離がこの値より小さければ接地と判定")]
    float floatingDistance = 0.02f;

    [SerializeField, Header("どのレイヤーのオブジェクトに当たったら")]
    LayerMask GroundLayerMask;

    private Collider collider;
    private bool IsGround = false;
    private bool IsRoof = false;

    RaycastHit hit;

    //実際には接地していないが、接地しているということにするブール
    private bool IsGroundFake = false;
    [Header("接地している判定の持続猶予フレーム")]
    [SerializeField] int IsGroundFrame = 5;
    int IsGroundCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGround = Physics.SphereCast(
            collider.transform.position + new Vector3(0, epsilon, 0),                   // 発射位置
            collider.transform.lossyScale.x * 0.5f,                                     // 大きさ　原点からの長さだから /2 しないといけない
            Vector3.down,                                                               // 方向
            out hit,                                                                    // あたったものの情報を格納する
            (collider.transform.lossyScale.y * 0.5f) + floatingDistance + epsilon,      // レイの長さ
            GroundLayerMask);                                                           // あたったもののレイヤーを見て指定したレイヤーと当たったらtrue


        // こっちが天井　まだ出来てない
        IsRoof = Physics.SphereCast(
            collider.transform.position - new Vector3(0, -epsilon, 0),
            collider.transform.lossyScale.x * 0.5f,
            Vector3.up,
            out hit,
            (collider.transform.lossyScale.y * 0.5f) + floatingDistance + epsilon,
            GroundLayerMask);
    }

    private void FixedUpdate()
    {
        //------------------------------------------------
        //接地猶予フレームのカウント
        //------------------------------------------------
        if (!IsGround)//空中に出るとカウントが進む
        {
            IsGroundCount++;
        }
        else if (IsGroundCount != 0)//接地したらリセット
        {
            IsGroundCount = 0;
        }


        if (IsGroundCount > IsGroundFrame)//猶予フレームを超えると、偽の接地判定もfalse
        {
            IsGroundFake = false;
        }
        if ((!IsGroundFake) && (IsGround))
        {
            IsGroundFake = true;
        }

    }

    public bool GetIsGroundFake() { return IsGroundFake; }

    public bool GetIsGround() { return IsGround; }

    public bool GetIsRoof() { return IsRoof; }
}
