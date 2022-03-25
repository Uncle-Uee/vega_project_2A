using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveYeti : MonoBehaviour
{
    #region VARIABLES

    [Header("Speed Properties")]
    public float HorizontalInput = 0f;
    public bool IsFacingRight = true;
    [SerializeField]
    private float YetiSpeed = 10;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    
    private readonly Vector3 _facingRotation = new Vector3(0f, 180f, 0f);

    #endregion

    #region UNITY METHODS

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Check Direction
        if (HorizontalInput > 0f && !IsFacingRight) Flip();
        else if (HorizontalInput < 0f && IsFacingRight) Flip();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void LateUpdate()
    {
        _animator.SetBool("IsMoving", HorizontalInput != 0f);
    }

    #endregion

    #region METHODS

    private void Movement()
    {
        _rigidbody2D.velocity = new Vector2(YetiSpeed * HorizontalInput, _rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        transform.Rotate(_facingRotation);
    }

    #endregion
}