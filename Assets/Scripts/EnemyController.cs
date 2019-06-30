using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の基本的な挙動を制御するコンポーネント
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] float m_fireInterval = 1f;
    float m_timer;

    void Start()
    {

    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (m_timer > m_fireInterval)
        {
            m_timer = 0;

            if (m_bulletPrefab)
            {
                Instantiate(m_bulletPrefab, this.transform.position, m_bulletPrefab.transform.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BulletController>())  // 衝突相手が Bullet だったら
        {
            Destroy(collision.gameObject);  // 衝突相手を破棄する
            Kill();
        }
    }

    void Kill()
    {
        Destroy(this.gameObject);
    }
}
