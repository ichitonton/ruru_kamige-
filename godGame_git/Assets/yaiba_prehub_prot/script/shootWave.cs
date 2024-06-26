using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootWave : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float shotSpeed;
    private float shotInterval;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {


            if (shotInterval % 600 == 0)
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward.x * -shotSpeed, 0.0f, transform.forward.z * -shotSpeed);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.

                Destroy(bullet, 3.0f);
            }
            shotInterval += 1;

        }
        else
        {
            shotInterval = 0;
        }
    }
}
