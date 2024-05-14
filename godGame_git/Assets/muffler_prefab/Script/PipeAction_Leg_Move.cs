using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAction_Leg_Move : MonoBehaviour
{
    public float player_vec = 1.0f;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(LegMove());
        }
    }

    private IEnumerator LegMove()
    {
        transform.position += transform.TransformDirection(Vector3.forward) * player_vec;
        yield return new WaitForSeconds(0.1f);
        transform.position += transform.TransformDirection(Vector3.forward) * player_vec;
        yield return new WaitForSeconds(0.1f);
        transform.position += transform.TransformDirection(Vector3.forward) * player_vec;
    }
}