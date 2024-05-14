using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0.1f, 0f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
    }
}
