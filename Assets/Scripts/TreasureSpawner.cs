using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureSpawner : MonoBehaviour
{
    [SerializeField] private Treasure _treasuarePrefab;
    [SerializeField] private float _rate;
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private float _nextSpawnTime = 0f;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }
    private void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }

        if (Time.time > _nextSpawnTime)
        {
            _nextSpawnTime = Time.time + _rate;
            Instantiate(_treasuarePrefab, transform.position, Quaternion.identity);
        }
    }
}