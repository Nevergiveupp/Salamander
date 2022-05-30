using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [Tooltip("�л�Ԥ����")]
    public GameObject enemyPrefab;

    [Tooltip("�л�����ʱ����")]
    public float generateInterval = 3;

    // Start is called before the first frame update
    void Start()
    {
        // GenerateEnemy();
        InvokeRepeating("GenerateEnemy", 0.1f, generateInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateEnemy()
    {
        GameObject node = Instantiate(enemyPrefab, this.transform);
        node.transform.position = this.transform.position;
        node.transform.localEulerAngles = new Vector3(0, 180, 0);

        // ����λ��xƫ��
        float dx = Random.Range(-60, 60);
        node.transform.Translate(dx, 0, 0, Space.Self);
    }
}
