using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBeamHead : MonoBehaviour
{
    public KeyCode shotkey = KeyCode.I;
    public GameObject bulletPrefab;
    public float shotpower = 5.0f;

    private GameObject currentBullet; // 生成された弾丸を保持するための変数

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shotkey))
        {
            Vector3 pos = transform.position + transform.forward * 0.5f;
            pos.y += 0.5f;

            currentBullet = Instantiate(bulletPrefab, pos, Quaternion.identity);

            currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shotpower, ForceMode.Impulse);
        }

        // キーが離されたら弾丸を消す
        if (Input.GetKeyUp(shotkey) && currentBullet != null)
        {
            Destroy(currentBullet);
        }
    }
}