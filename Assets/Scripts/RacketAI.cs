using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketAI : MonoBehaviour
{
    public float racketSpeed;  // �������� �������� �������
    public GameObject ball;    // ������ �� ���
    public float followThreshold = 0.2f; // ����� ��� �������� (������ ����� �������� - �� ���������)

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ������� ������� ����
        float ballY = ball.transform.position.y;

        // ��������� ������� ����� �������� ���� � �������
        float directionY = ballY - transform.position.y;

        // ���� ������� ������ ��������� ������, ������� ����� ��������
        if (Mathf.Abs(directionY) > followThreshold)
        {
            // ����������� �����������, ����� �������� ���������� ����������
            rb.velocity = new Vector2(0, Mathf.Sign(directionY)) * racketSpeed;
        }
        else
        {
            // ������������� �������, ���� ��� �����
            rb.velocity = Vector2.zero;
        }
    }
}
