using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LateraMovement))]

public class EnemyManager : MonoBehaviour
{
    LateraMovement lateraMovement;
    // Start is called before the first frame update
    void Start()
    {
        lateraMovement = GetComponent<LateraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
