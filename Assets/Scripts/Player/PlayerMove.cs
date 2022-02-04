using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;
    private PlayerInput _playerInput;


    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    
    private void Update()
    {
        Vector2 direction = _playerInput.Player.Move.ReadValue<Vector2>();
        TryMove(direction);
    }

    private void TryMove(Vector2 direction)
    {
        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 _moveDirection = new Vector3(direction.x, direction.y);
        transform.position += _moveDirection * scaledMoveSpeed;
        
      
    }
    

}
