using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyTravelPoint[] _travelPoints;
    [SerializeField] private List<Vector2> _travelPointsCoordinate;
    [SerializeField] private float _speed;

    private Coroutine _moving;

    void Awake()
    {
        _travelPoints = GetComponentsInChildren<EnemyTravelPoint>();

        if (_travelPoints == null)
        {
            Destroy(gameObject);
        }
        else
        {
            for (int i = 0; i < _travelPoints.Length; i++)
            {
                _travelPointsCoordinate.Add(_travelPoints[i].transform.position);
            }

            transform.position = _travelPointsCoordinate[0];
        }

        if (_travelPointsCoordinate.Count > 1)
        {
            _moving = StartCoroutine(MoveToPoint());
        }        
    }

    private IEnumerator MoveToPoint()
    {
        for (int i = 0; i < _travelPointsCoordinate.Count; i++)
        {
            while ((Vector2)transform.position != _travelPointsCoordinate[i])
            {
                this.transform.position = Vector2.MoveTowards(transform.position, _travelPointsCoordinate[i], Time.deltaTime * _speed);
                yield return null;
            }

            if (i == _travelPointsCoordinate.Count - 1)
            {
                i = -1;
            }
        }
    }
}
