using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashWave : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float shotSpeed;
    private float shotInterval;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {


            if (shotInterval % 600 == 0)
            {
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(0.0f,0.0f,0.0f);
                bulletRb.AddRelativeForce(0.0f, 0.01f, 0.0f);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.

                Destroy(bullet, 0.1f);
            }
            shotInterval += 1;

        }
        else { shotInterval = 0; }
    }
}
