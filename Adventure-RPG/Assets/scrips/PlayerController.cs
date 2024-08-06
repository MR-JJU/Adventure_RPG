using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    private bool isMoving;

    public Vector2 input;

    private Animator animator;

    public LayerMask solidObjectsLayer;

    public LayerMask NPCLayer;

    public float Radius;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void HandleUpdate()
    {
        if (!isMoving) // same as isMoving != true or isMoving = false
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            if (input.x != 0)           // prevent diagonal movement 
            {
                input.y = 0;
            }                           //


            if (input != Vector2.zero)
            {   
                animator.SetFloat("moveX", input.x);              //animation 
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x; // targetPos.x = targetPos.x + input.x
                targetPos.y += input.y; // targetPos.y = targetPos.y + input.y

                if (IsWalkable(targetPos)) 
                { 
                    StartCoroutine(Move(targetPos));
                }

               

            }
        }

        animator.SetBool("isMoving", isMoving);

        // do Interact() when T is pressed 
        if (Input.GetKeyDown(KeyCode.T))
        {
            Interact();
        }

        // define the direction the player is looking and the area the player can interact with
        void Interact ()
        {
            var facingDirection = new Vector3 (animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            var interactPosition = transform.position + facingDirection;
            // Debug.DrawLine(transform.position, interactPosition, Color.red, 1f); // in Scene is a red line visible when t is pressed 

            var collider = Physics2D.OverlapCircle(interactPosition, 0.2f, NPCLayer);

            if (collider != null) 
            {
                collider.GetComponent<Interactable>()?.Interact();
            }

        }

    }

    IEnumerator Move(Vector3 targetPos)
    {

        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) // While Player is moving 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * 5 * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

    }

    // return false if you are on a solid Object, NPCLayer and you dont move
    // return True else 
    //**cant walk through these layers**//
    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, Radius, solidObjectsLayer | NPCLayer) != null) 
        {
            return false;
        }
        return true;
    }

}
