using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeam_RightHand : MonoBehaviour
{
    public GameObject player; // プレイヤーオブジェクト
    public GameObject halfTorusColliderPrefab; // 半トーラスの当たり判定のプレハブ
    public KeyCode keyToPress = KeyCode.J; // 生成をトリガーするキー


    private GameObject currentBullet; // 生成された弾丸を保持するための変数

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // キーが押されたら半トーラスの当たり判定を生成
        if (Input.GetKeyDown(keyToPress))
        {
            // プレイヤーの前方に当たり判定を生成
            Vector3 spawnPosition = player.transform.position + player.transform.forward * 2.0f; // プレイヤーの前方2メートル
            Quaternion spawnRotation = player.transform.rotation;
            GameObject halfTorusCollider = Instantiate(halfTorusColliderPrefab, spawnPosition, spawnRotation);

            // 半トーラスの当たり判定にコライダーがあるか確認
            Collider collider = halfTorusCollider.GetComponent<Collider>();
            if (collider != null)
            {
                // コライダーの衝突イベントを監視
                //collider.gameObject.GetComponent<Collider>().attachedRigidbody.OnTriggerEnter.AddListener(OnTriggerEnter);
            }

            //void OnTriggerEnter(Collider other)
            //{
            //    // 衝突したオブジェクトが"enemy"タグを持つ場合は削除する
            //    if (other.CompareTag("enemy"))
            //    {
            //        Destroy(other.gameObject);
            //    }
            //}
        }

        // キーが離されたら弾丸を消す
        if (Input.GetKeyUp(KeyCode.J) && halfTorusColliderPrefab != null)
        {
            Destroy(halfTorusColliderPrefab);
        }


    }


    
}

