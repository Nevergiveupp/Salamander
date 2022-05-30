using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Tooltip("�ӵ������ٶ�")]
    public float speed = 1;

    [Tooltip("�ӵ�����ʱ��")]
    public float lifetime = 3;

    [Tooltip("��ը������Ч��Prefab�ļ�")]
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        // ��ʱ�����ӵ�
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    // ��ײ����ʱ��Ϣ����
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�ӵ�������ײ��other=" + other.name);

        // ������еĲ��ǵл���ֱ�ӷ���
        if (!other.name.Contains("Enemy"))
        {
            return;
        }

        // �����ӵ��͵���
        Object.Destroy(this.gameObject);
        Object.Destroy(other.gameObject);

        // ����һ��������Ч��ʵ�ֱ�ըЧ��
        GameObject effectNode = Instantiate(explosionEffect, null);
        // ��ըλ��ָ��Ϊ��ǰ�ӵ�λ��
        effectNode.transform.position = this.transform.position;
        // ��������Ч������Ϻ󣬸ýڵ��Զ�����

    }

    // �Ի�
    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }


}
