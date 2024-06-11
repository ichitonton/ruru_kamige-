using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlashManajar : MonoBehaviour
{
    private float destroyTime = 0.05f;

    private bool rotateMove = false;

    private bool aaa = false;

    // Start is called before the first frame update
    void Start()
    {
        //destroyTime = 0.05f; 
        //rotateMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateMove)
        {
            transform.Rotate(new Vector3(0, 3600, 0) * Time.deltaTime);
        }
        destroyTime -= Time.deltaTime;
        if (destroyTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetRotateMove()
    {
        rotateMove = true;
        destroyTime = 1;
    }
}
