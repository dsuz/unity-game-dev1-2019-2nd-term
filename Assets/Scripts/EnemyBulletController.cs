using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 dir = player.transform.position - this.transform.position;
        dir = dir.normalized;
        m_rb.velocity = dir * m_speed;
    }
}
