using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RequireComponentで絶対にrigidbodyを得る
[RequireComponent(typeof(Rigidbody))]

public class Jump : MonoBehaviour
{
    [Header("ジャンプの最大速度と落下の最大速度")]
    [SerializeField] private float maxJumpSpeedY = 13.0f;
    [SerializeField] private float maxFallSpeedY = 13.0f;
    [Header("ジャンプ時の最初の速さ")]
    [SerializeField] private float StartAccelY = 5.0f;
    float AccelY = 0;
    public bool isJumping { get; private set; }

    [Header("ジャンプの最高到達点（厳密には違う）")]
    [SerializeField] float maxHeight = 4.0f;
    float jumpPos = 0.0f;

    //ジャンプ方向
    Vector3 jumpForward = new Vector3(0.0f, 1.0f, 0.0f);

    //------------------------------------------------
    //キャラクターのリジッドボディ
    //------------------------------------------------
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartJump()    //ジャンプ開始関数
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
            //高くなればなるほど力が弱くなる式
            AccelY = ((jumpPos + maxHeight) - transform.position.y + 2) * StartAccelY;
            //一度縦の速さを０に
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(jumpForward * AccelY, ForceMode.Impulse);


            //自分が決めた高さより下の場合　ジャンプを継続
            if (transform.position.y - jumpPos < maxHeight)
            {
                //つまり、ここには、天井がなければ最大の高さまで上昇しなければ
            }
            else
            {
                isJumping = false;
            }
        }
        else
        {
            //ジャンプしていないなら、最初の力をリセット
            if (StartAccelY != AccelY)
            {
                AccelY = StartAccelY;
            }
        }

        //最大スピードを超えないようにする
        if (rb.velocity.y >= maxJumpSpeedY)//正
        {
            rb.velocity = new Vector3(rb.velocity.x, maxJumpSpeedY,rb.velocity.z);
        }
        else if (rb.velocity.y <= -maxFallSpeedY)//負
        {
            rb.velocity = new Vector3(rb.velocity.x, -maxFallSpeedY, rb.velocity.z);
        }
    }
}
