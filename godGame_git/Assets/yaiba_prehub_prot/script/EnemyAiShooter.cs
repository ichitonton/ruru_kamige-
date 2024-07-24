using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyAiShooter : MonoBehaviour
{
    public GameObject searchRange;
    public float moveSpeed;

    float time;
    float sTime;
    bool move;
    int mode;
    Serch serch;

    public GameObject bulletPrefab;
    bool shoot = false;
    int shootCount;
    float shootRate = 0.3f;
    float shootTime = 0.0f;
    float shotSpeed = 10.0f;

    Rigidbody rb;
    //public GameObject[] objects = new GameObject[10];
    Vector3 dis;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        time = 0.0f;
        dis = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //shootTime = Time.deltaTime;
        serch = searchRange.GetComponent<Serch>();
        if (time >= 0.1f)
        {
            time = 0.0f;
            //敵を検知！
            if (serch.GetDetection())
            {
                move = true;
                shoot = true;
                shootCount = 0;
                //shootTime = 0.0f;
            }

            if (!move)
            {
                dis = new Vector3(0.0f, 0.0f, 0.0f);
                velocity = new Vector3(0.0f, 0.0f, 0.0f);
            }

            if (move)
            {

                sTime += 0.1f;
                //ターゲットを向く
                Debug.Log("ターゲットを向く");
                Vector3 tarPos = serch.getSerchTarget().transform.position;
                tarPos.y = this.transform.position.y;
                this.transform.LookAt(tarPos);

                dis = serch.getSerchTarget().transform.position - this.transform.position;
                dis = dis.normalized;//正規化

                //プレイヤーから離れる
                velocity.x = -dis.x * moveSpeed;
                velocity.z = -dis.z * moveSpeed;
                //}
                move = false;
            }
        }
        if (shoot)
        {
            shootTime += Time.deltaTime;
            if (shootCount >= 3)
            {
                shoot = false;
            }
            if (shootTime >= shootRate)
            {
                Debug.Log("敵のショット！！");
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.AddForce(transform.forward.x * shotSpeed, 0.0f, transform.forward.z * shotSpeed, ForceMode.VelocityChange);

                //射撃されてから3秒後に銃弾のオブジェクトを破壊する.
                Destroy(bullet, 3.0f);
                shootTime = 0.0f;
                shootCount++;
            }

        }

        //rb.transform.position += velocity * 0.01f;
        //rb.GetPointVelocity();
        rb.AddForce(velocity * 1.0f, ForceMode.Acceleration);

    }
}
