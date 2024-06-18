using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    public float conveyorVelocity;

    Vector3 tarVel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            tarVel = new Vector3(
                    conveyorVelocity * Mathf.Sin(this.transform.eulerAngles.y * Mathf.Deg2Rad),
                    0.0f,
                    conveyorVelocity * Mathf.Cos(this.transform.eulerAngles.y * Mathf.Deg2Rad));

            other.transform.position += tarVel; 
        }
    }
}
