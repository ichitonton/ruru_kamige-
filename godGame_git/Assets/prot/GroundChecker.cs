using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundChacker : MonoBehaviour
{
    //public bool IsGround { get; private set; }

    // ‚ ‚½‚Á‚½
    private bool IsGround = false;

    //[SerializeField] BoxCollider Collider;

    [Header("Collider‚Æ’n–Ê‚Ì‹——£‚ª‚±‚Ì’l‚æ‚è¬‚³‚¯‚ê‚ÎÚ’n‚Æ”»’è‚·‚é")]
    public float FloatingDistance = 0.01f;

    [Header("BoxCast‚Ì”­¶Œ³‚ğ­‚µã‚É‚¸‚ç‚·‹——£")]
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
    }

    public bool GetIsGround() { return IsGround; }
}
