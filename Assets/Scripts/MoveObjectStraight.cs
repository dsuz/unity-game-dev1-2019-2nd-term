using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveObjectStraight : MonoBehaviour
{
    [SerializeField] Vector2 m_direction = Vector2.down;
    [SerializeField] float m_speed = 1.5f;
    Rigidbody2D m_rb;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_rb.velocity = m_direction.normalized * m_speed;
    }
}
