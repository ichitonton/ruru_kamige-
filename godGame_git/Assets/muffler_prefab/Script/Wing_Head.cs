using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wing_Head : MonoBehaviour
{
    public GameObject wing;
    public Transform player;
    public Vector3 pos;
    public Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.position;
        rot = player.localEulerAngles;

        if (Input.GetKeyDown(KeyCode.I))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(wing, new Vector3(Random.Range(pos.x - 5f, pos.x + 5f), Random.Range(pos.y - 2f, pos.y + 2f), pos.z - 2f), Quaternion.Euler(rot.x + 90f, rot.y, rot.z));
            }
        }
    }
}
