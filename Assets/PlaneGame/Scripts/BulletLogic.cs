using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Tooltip("子弹飞行速度")]
    public float speed = 1;

    [Tooltip("子弹飞行时长")]
    public float lifetime = 3;

    [Tooltip("爆炸粒子特效的Prefab文件")]
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        // 定时销毁子弹
        Invoke("SelfDestroy", lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed * Time.deltaTime, Space.Self);
    }

    // 碰撞发生时消息函数
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("子弹发生碰撞，other=" + other.name);

        // 如果击中的不是敌机，直接返回
        if (!other.name.Contains("Enemy"))
        {
            return;
        }

        // 销毁子弹和敌人
        Object.Destroy(this.gameObject);
        Object.Destroy(other.gameObject);

        // 创建一个粒子特效，实现爆炸效果
        GameObject effectNode = Instantiate(explosionEffect, null);
        // 爆炸位置指定为当前子弹位置
        effectNode.transform.position = this.transform.position;
        // 当粒子特效播放完毕后，该节点自动销毁

    }

    // 自毁
    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }


}
