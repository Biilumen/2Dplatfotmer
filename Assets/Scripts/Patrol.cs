using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Animator _animator;
    private Vector3 _enemyScale;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Run", true);
        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
        _enemyScale = transform.localScale;
    }

    void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        Vector2 direction = target.position - transform.position;
        if (transform.position == target.position)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
        if (direction.x < 0)
        {
            _enemyScale.x = 1;
        }
        if (direction.x > 0)
        {
            _enemyScale.x = -1;
        }
        transform.localScale = _enemyScale;
    }
}
