using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyTravelPoint _firstPoint;
    [SerializeField] private EnemyTravelPoint _secondPoint;
    [SerializeField] private float _speed;

    private Coroutine _moving;

    void Start()
    {
        transform.position = _firstPoint.transform.position;
        _moving = StartCoroutine(MoveToPoint(_secondPoint.transform.position));
    }

    void Update()
    {
        if (transform.position.x == _firstPoint.transform.position.x && transform.position.y == _firstPoint.transform.position.y)
        {
            StopCoroutine(_moving);
            _moving = StartCoroutine(MoveToPoint(_secondPoint.transform.position));
        }
        else if (transform.position.x == _secondPoint.transform.position.x && transform.position.y == _secondPoint.transform.position.y)
        {
            StopCoroutine(_moving);
            _moving = StartCoroutine(MoveToPoint(_firstPoint.transform.position));
        }
    }

    private IEnumerator MoveToPoint(Vector3 lastPoint)
    {
        while (transform.position.x != lastPoint.x && transform.position.y != lastPoint.y)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, lastPoint, Time.deltaTime * _speed);
            yield return null;
        }
    }
}
