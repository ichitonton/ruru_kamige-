using UnityEngine;
using System.Collections;

public class Gra : MonoBehaviour
{
    RaycastHit hit;

    //[SerializeField]
    //bool isEnable = false;

    public LayerMask a;

    public BoxCollider boxCollider;

    private bool ig;

    private void Update()
    {
        ig = Physics.BoxCast(boxCollider.transform.position, boxCollider.transform.lossyScale * 0.5f, Vector3.down, out hit, boxCollider.transform.rotation, 1.11f, a);
    }

    public bool GetIG() { return ig; }

    /*
    void OnDrawGizmos()
    {
        if (isEnable == false)
            return;

        var scale = transform.lossyScale.x * 0.5f;

        //var isHit = Physics.BoxCast(transform.position, Vector3.one * scale, -transform.up, out hit, transform.rotation,10.0f, a);
        var isHit = Physics.BoxCast(boxCollider.transform.position, boxCollider.transform.lossyScale * 0.5f, Vector3.down, out hit, boxCollider.transform.rotation,10.0f, a);
        //if (isHit)
        //{
        //    Gizmos.DrawRay(transform.position, -transform.up * hit.distance);
        //    Gizmos.DrawWireCube(transform.position + -transform.up * hit.distance, Vector3.one * scale * 2);
        //}
        //else
        //{
        //    Gizmos.DrawRay(transform.position, -transform.up * 100);
        //}

        if (isHit) print("‚¶‚Ü‚ñ");
        else print("‚»‚ç");
    }
    */
}