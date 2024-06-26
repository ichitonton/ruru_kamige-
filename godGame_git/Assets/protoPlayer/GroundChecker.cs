using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundChacker : MonoBehaviour
{
    //public bool IsGround { get; private set; }

    // あたった
    private bool IsGround = false;

    //[SerializeField] BoxCollider Collider;

    [Header("Colliderと地面の距離がこの値より小さければ接地と判定する")]
    public float FloatingDistance = 0.01f;

    [Header("BoxCastの発生元を少し上にずらす距離")]
    public float Epsilon = 0.01f;

    public LayerMask GroundLayerMask;

    private float scale;

    RaycastHit hit;

    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        scale = boxCollider.transform.lossyScale.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        IsGround = Physics.BoxCast(
            boxCollider.transform.position + new Vector3(0, Epsilon, 0),
            boxCollider.transform.lossyScale * 0.5f,
            Vector3.down,
            out hit,
            boxCollider.transform.rotation,
            FloatingDistance + Epsilon,
            GroundLayerMask);

        //if (IsGround) print("じめん");
        //else print("そら");

        //print(boxCollider.transform.lossyScale);
    }

    public bool GetIsGround() { return IsGround; }
}
