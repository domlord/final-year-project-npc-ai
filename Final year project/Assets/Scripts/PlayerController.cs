using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private Vector2 _moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = InputManager.Instance.MoveInput;

        rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
    }
}
