using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    private float _moveInput;
    private Rigidbody2D _rigidbody;
    private Vector3 _playerScale;
    private Animator _animator;
    private bool _grounded;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(_moveInput * _speed, _rigidbody.velocity.y);
        _playerScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            _playerScale.x = -1;
            _animator.SetBool("Run",true);
        }
        if  (Input.GetAxis("Horizontal") > 0)
        {
            _playerScale.x = 1;
            _animator.SetBool("Run", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_grounded)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                _animator.SetTrigger("Jump");
            }
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            _animator.SetBool("Run", false);
        }
        transform.localScale = _playerScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _grounded = false;
    }
}
