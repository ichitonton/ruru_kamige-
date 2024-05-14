using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackManager : MonoBehaviour
{
    public float attackPower;
    public string tagTarget;
    public bool isHitDestroy = true;
    public bool isHitContinuity = false;
    bool oldHit = false;
    // Start is called before the first frame update
    void Start()
    {
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
                //攻撃がヒットしたときに消す
                if (isHitDestroy)
                {
                    if (isHitDestroy)
                    {
                        Destroy(gameObject);
                    }
                }
                oldHit = true;
            }
        }
    }
}
