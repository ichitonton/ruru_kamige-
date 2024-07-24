using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public float attackPower;
    public float chargeGage;
    public string tagPlayer;
    public string tagTarget;
    public bool isHitDestroy = true;
    public GameObject destroyObj;
    public bool isHitContinuity = false;
    public bool gage;//ゲージの概念があるかどうか
    bool oldHit = false;
    GameObject player;

    [SerializeField] public TagField tagField;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find(tagPlayer);
        if (!GameObject.Find(tagPlayer))
        {
            //Debug.Log("このタグのオブジェクトが見つかりませんでした：" + tagTarget);
        }
        else
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag(tagTarget))
        {
            Debug.Log("このタグのオブジェクトが見つかりませんでした：" + tagTarget);
        }
        else if (other.CompareTag(tagTarget))
        {
            //連続的に攻撃判定を与える||初めてのヒット
            if (oldHit && isHitContinuity || !oldHit)
            {
                //攻撃処理
                hpManager target = other.GetComponent<hpManager>();
                target.TakeDamage(attackPower);
                Debug.Log("このタグのオブジェクトにヒット：" + tagTarget);

                //攻撃がヒットしたときにチャージを溜める
                if (gage)
                {
                    player = GameObject.Find(tagPlayer);
                    chargeManager charge = player.GetComponent<chargeManager>();
                    charge.TakeCharge(chargeGage);
                }

                //攻撃がヒットしたときに消す
                if (isHitDestroy)
                {
                    if (isHitDestroy)
                    {
                        Debug.Log("destroy");
                        Destroy(destroyObj);
                    }
                }
                oldHit = true;
            }
        }
    }
}
