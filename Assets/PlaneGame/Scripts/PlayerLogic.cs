using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [Tooltip("�ӵ��ڵ�Ԥ����")]
    public GameObject bulletPrefab;

    [Tooltip("�ӵ��ڵ�ĸ��ڵ�")]
    public Transform bulletFolder;

    [Tooltip("�ӵ�������")]
    public Transform firePoint;

    [Tooltip("�ӵ�������")]
    public float fireInterval = 0.1f;

    [Tooltip("ƽ���ٶ�")]
    public float moveSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", fireInterval, fireInterval);
    }

    // Update is called once per frame
    void Update()
    {
        float dx = 0;

        if(Input.GetKey(KeyCode.A))
        {
            dx = -moveSpeed;
        }
        if(Input.GetKey(KeyCode.D))
        {
            dx = moveSpeed;
        }
        this.transform.Translate(dx, 0, 0, Space.Self);
    }

    private void Fire()
    {
        // ʵ�����ӵ��ڵ�
        GameObject node = Instantiate(bulletPrefab, bulletFolder);

        // �����ӵ�������
        node.transform.position = firePoint.position;
    }
}
