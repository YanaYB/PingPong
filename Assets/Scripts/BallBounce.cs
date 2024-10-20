using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;

        // ����������, � ����� �������� ��������� ������������
        if (collision.gameObject.name == "Racket1")
        {
            positionX = 1; // ��� ����� ������
        }
        else
        {
            positionX = -1; // ��� ����� �����
        }

        // ��������� ������� �� ��� Y ��� �����������
        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        // ����������� ������� ������
        ballMovement.IncreaseHitCounter(); // ��������� ���������� ����� ������

        // ������� ��� � ����� �����������
        ballMovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, ��� ������������ ��������� � ����� �� �������
        if (collision.gameObject.name == "Racket1" || collision.gameObject.name == "Racket2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.name == "RightBorder")
        {
            scoreManager.PlayerGoal(1);
            ballMovement.player1Start = false;
            StartCoroutine(ballMovement.Launch());
        }
        else if (collision.gameObject.name == "LeftBorder")
        {
            scoreManager.PlayerGoal(2);
            ballMovement.player1Start = true;
            StartCoroutine(ballMovement.Launch());
        }
    }
}
