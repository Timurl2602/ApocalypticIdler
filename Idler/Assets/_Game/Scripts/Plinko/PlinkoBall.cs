using System;
using IdleGame;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlinkoBall : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float MoveSpeed;
    public float LimitLeft;
    public float LimitRight;
    
    public bool CanMove;

    private void Start()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.PlinkoCanBePlayed)
        {
            CanMove = true;
        }
        if (CanMove)
        {
            Vector3 moveOffset = Vector3.zero;
            moveOffset.x = Input.GetAxis("Horizontal");
            moveOffset.x = moveOffset.x * MoveSpeed * Time.deltaTime;
            Vector3 newPosition = transform.position + moveOffset;
            if (newPosition.x > LimitRight)
            {
                newPosition.x = LimitRight;
            }

            if (newPosition.x < LimitLeft)
            {
                newPosition.x = LimitLeft;
            }

            transform.position = newPosition;

            if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.PlinkoCanBePlayed)
            {
                CanMove = false;
                rigidbody.isKinematic = false;
                rigidbody.AddForce(new Vector2(Random.Range(-2,2), Random.Range(-2,2)), ForceMode2D.Impulse);
            }
        }
    }
    
}
