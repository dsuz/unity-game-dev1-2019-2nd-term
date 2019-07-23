using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵の基本的な挙動を制御するコンポーネント
/// </summary>
public class EnemyController : MonoBehaviour
{
    /// <summary>発射する弾のプレハブ</summary>
    [SerializeField] GameObject m_bulletPrefab;
    /// <summary>弾を発射する間隔（秒）</summary>
    [SerializeField] float m_fireInterval = 1f;
    /// <summary>破壊することで得られる得点</summary>
    [SerializeField] int m_score = 100;
    /// <summary>爆発エフェクト</summary>
    [SerializeField] GameObject m_explosionEffect;
    /// <summary>既にやられているかどうかを判定するフラグ</summary>
    bool m_isDead = false;
    /// <summary>タイマー</summary>
    float m_timer;

    void Start()
    {

    }

    void Update()
    {
        // m_fireInterval 秒ごとに弾を生成する
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

    /// <summary>
    /// やられた時に呼ぶ関数
    /// </summary>
    void Kill()
    {
        // 初回のみ得点を加算する
        if (m_isDead == false)
        {
            m_isDead = true;

            GameObject go = GameObject.Find("GameManager");
            if (go)
            {
                GameManager gm = go.GetComponent<GameManager>();
                if (gm)
                {
                    gm.AddScore(m_score);
                }
            }

            // 爆発エフェクトを置く
            if (m_explosionEffect)
            {
                Instantiate(m_explosionEffect, this.transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
