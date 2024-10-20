using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;    // ��������� �������� ����
    public float extraSpeed;    // �������������� �������� ��� ������
    public float maxExtraspeed; // ������������ �������������� ��������

    public bool player1Start = true; // ����������, ��� ������ ����

    private int hitCounter = 0;  // ���������� ������
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    private void RestartBall()
    {
        rb.velocity = Vector2.zero;       // ������������� ���
        transform.position = Vector2.zero; // ���������� ��� � ����� ����
    }

    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1); // ��������� �������� ����� �������

        // ��������� ���������� ���� ��� ��������� ���������� ����
        float randomAngle = Random.Range(-30f, 30f); // ��������� ���� � ��������� [-30, 30]

        // ����������� ����������� �������� � ����������� �� ����, ��� ��������
        Vector2 direction;
        if (player1Start)
        {
            // ��� ����� ����� � ��������� ������������ �����������
            direction = new Vector2(-1, Mathf.Tan(randomAngle * Mathf.Deg2Rad));
        }
        else
        {
            // ��� ����� ������ � ��������� ������������ �����������
            direction = new Vector2(1, Mathf.Tan(randomAngle * Mathf.Deg2Rad));
        }

        // ��������� ���
        MoveBall(direction);
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;  // ����������� ������ �����������

        float ballSpeed = startSpeed + hitCounter * extraSpeed;  // �������� ����

        rb.velocity = direction * ballSpeed;  // ��������� �������� � ����
    }

    public void IncreaseHitCounter()
    {
        // ����������� ������� ������, ���� ��� �� �������� ������������ ��������
        if (hitCounter * extraSpeed < maxExtraspeed)
        {
            hitCounter++;
        }
    }
}
