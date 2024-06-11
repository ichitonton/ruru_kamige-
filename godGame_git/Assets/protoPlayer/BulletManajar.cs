using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManajar : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 direction;

    private float destroyTime;

    private bool beeeeeem = false;
    // Start is called before the first frame update
    void Start()
    {
        destroyTime = 1;
        //print(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (beeeeeem) transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
        destroyTime -= Time.deltaTime;

        if (destroyTime < 0)
        {
            Destroy(gameObject);
        }

        transform.position += direction * speed;



    }

    public void SetDirection(Vector3 d)
    {
        direction = d;
    }

    public void SetHead(Vector3 d)
    {
        transform.localScale *= 3;
        direction = d;
        speed = 0.1f;
    }

    public void SetBeem(Vector3 d)
    {
        transform.localScale *= 3;
        direction = d;
        speed = 0.1f;
        beeeeeem = true;
    }
}
