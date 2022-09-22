using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public event Action OnMouseClick;

    public InputData inputData;

    public float speed = 10f;

    Vector3 _clickedPosition;

    Vector3 _releasedPosition;

    Vector3 _direction;

    Rigidbody2D _rb;

    BallEffects _ballEffects;

    public LayerMask layerToCollide;

    bool _hitBlock;

    public event Action OnScreenOff;

    [SerializeField] private AudioSource ballHitSoundEffect;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _ballEffects = GetComponent<BallEffects>();
    }

    void Update()
    {
        HandleMovement();

        if (!GetComponent<Renderer>().isVisible)
        {
            Debug.Log("Ball is off screen");
            OnScreenOff?.Invoke();
        }
    }

    bool CheckIfHitBlock()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D _hit =
            Physics2D
                .Raycast(_ray.origin, _ray.direction, 100f, layerToCollide);

        return _hit;
    }

    void HandleMovement()
    {
        if (inputData.isPressed)
        {
            // Does not spawn ball if ball is on top of a block
            _hitBlock = CheckIfHitBlock();
            if (_hitBlock)
            {
                return;
            }

            // Get the position of the mouse when it is pressed
            _clickedPosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _clickedPosition =
                new Vector3(_clickedPosition.x, _clickedPosition.y, 0);

            // Reset the direction and velocity
            transform.position = _clickedPosition;
            _rb.velocity = Vector3.zero;

            // Spawn the trail
            _ballEffects.SetTrailActive(true);

            // If the mouse is clicked, invoke the OnMouseClick event
            OnMouseClick?.Invoke();
        }

        if (inputData.isHeld)
        {
            // Does not spawn ball if ball is on top of a block
            if (_hitBlock)
            {
                return;
            }

            // Trail when the mouse is held
            _ballEffects
                .SetTrailPosition(_clickedPosition,
                Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

        if (inputData.isReleased)
        {
            // Does not spawn ball if ball is on top of a block
            if (_hitBlock)
            {
                return;
            }

            // Get the position of the mouse when it is released
            _releasedPosition =
                Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _releasedPosition =
                new Vector3(_releasedPosition.x, _releasedPosition.y, 0f);

            // Calculate the direction of the mouse movement
            _direction = (_releasedPosition - _clickedPosition).normalized;
            _rb.velocity = _direction * speed;

            // Disable the trail
            _ballEffects.SetTrailActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            _direction =
                Vector3
                    .Reflect(_rb.velocity, other.contacts[0].normal)
                    .normalized;
            _rb.velocity = _direction * speed;
            ballHitSoundEffect.Play();
        }
    }
}
