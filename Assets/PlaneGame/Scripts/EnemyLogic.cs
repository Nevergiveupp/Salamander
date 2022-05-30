using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [Tooltip("ǰ���ٶ�")]
    public float zSpeed = 10;

    // �����ٶ�
    float xSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        // ÿ��ı�һ�κ����ٶ�
        InvokeRepeating("SnakeMove", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        float dz = zSpeed * Time.deltaTime;
        float dx = xSpeed * Time.deltaTime;

        this.transform.Translate(dx, 0, dz, Space.Self);
    }

    // ��Ƥ��λ
    void SnakeMove()
    {
        // 4���ٶ�ѡ��
        float[] options = { -10, -5, 5, 10 };
        // ���ָ��һ���ٶ�����
        int se1 = Random.Range(0, options.Length);
        // ���ٶȸ�����������
        xSpeed = options[se1];
    }
}
