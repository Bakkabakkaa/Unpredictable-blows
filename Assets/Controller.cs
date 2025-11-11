using System;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Controller : MonoBehaviour
{
    private static readonly int Forward = Animator.StringToHash("forward");
    private static readonly int Back = Animator.StringToHash("back");
    private static readonly int Attack = Animator.StringToHash("attack");
    private static readonly int Punch = Animator.StringToHash("punch");
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool(Forward, true);
            _animator.SetBool(Back, false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool(Back, true);
            _animator.SetBool(Forward, false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (GetRandomPunch() == 1)
            {
                _animator.SetTrigger(Attack);
            }
            else
            {
                _animator.SetTrigger(Punch);
            }
            
        }
    }

    private int GetRandomPunch()
    {
        return UnityEngine.Random.Range(1, 3);
    }
}
