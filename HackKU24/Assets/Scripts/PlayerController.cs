using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 4;
    public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;
    private Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate() {

        if(movementInput != Vector2.zero) {

            bool success = TryMove(movementInput);

            if(!success) {
                success= TryMove(new Vector2(movementInput.x, 0));

                if(!success) {
                    TryMove(new Vector2(0, movementInput.y));
                }
            }

        }

    }

    private bool TryMove(Vector2 direction) {
        int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0) {
                Debug.Log("Collision");
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            };
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
        if(movementInput.x != 0 || movementInput.y != 0) {
            animator.SetFloat("X", movementInput.x);
            animator.SetFloat("Y", movementInput.y);

            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }


        Debug.Log(movementValue);
    }
}
