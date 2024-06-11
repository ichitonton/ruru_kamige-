using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    private float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        destroyTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime < 0)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            destroyTime = 5;
        }
    }
}
