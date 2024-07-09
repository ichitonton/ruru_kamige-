using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DiagonalMovement))]
//[RequireComponent(typeof(AttackManager))]     // ‚¦‚ñ‚¿‚á‚ñ‚ª‚Â‚­‚Á‚½‚â‚Â

public class BulletManagar : MonoBehaviour
{
    private Vector3 shotDirection;
    private DiagonalMovement diagonalMovement;

    BulletManagar() 
    {
        shotDirection = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        //shotDirection= Vector3.zero;
        diagonalMovement = GetComponent<DiagonalMovement>();


        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        diagonalMovement.Move(shotDirection);
    }

    public void SetShotDirection(Vector3 direction) { 
        shotDirection = direction;
    }
}
