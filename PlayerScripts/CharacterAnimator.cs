using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Transform objectTransform;
    private Vector3 previousPosition;
    private bool isShooting = false;
    private bool isRightMouseButtonDown = false;
    private bool isIdle = true;
    public bool CanAim { get; set; }

    private void Awake()
    {
        objectTransform = transform;
        previousPosition = objectTransform.position;
    }
    private void Update()
    {
       HandleMouseInputs();
       if (isRightMouseButtonDown)
       {
         UpdateAimParameters();
       }

    }
    private void FixedUpdate()
    {
        UpdateAnimationParameters();
        previousPosition = objectTransform.position;
    }
    private void HandleMouseInputs()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseButtonDown = true;
            if (CanAim)
            {
                isIdle = false;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightMouseButtonDown = false;
            if (!isShooting)
            {
                ResetAimParameters();
                CheckIdleState();
            }
        }
        if (isRightMouseButtonDown && Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            if (CanAim)
            {
                isIdle = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
            if (!isRightMouseButtonDown)
            {
                CheckIdleState();
            }
        }
        animator.SetBool("isShooting", isShooting && CanAim);
    }
    private void UpdateAimParameters()
    {
        if (!CanAim) return; // Return early if CanAim is false

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePosition - objectTransform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        bool isAimRight = (angle > -30f && angle <= 30f);
        bool isAimUp = (angle > 30f && angle <= 150f);
        bool isAimLeft = (angle > 150f || angle <= -150f);
        bool isAimDown = (angle > -150f && angle <= -30f);

        animator.SetBool("isAimLeft", isAimLeft);
        animator.SetBool("isAimRight", isAimRight);
        animator.SetBool("isAimFront", isAimDown);
        animator.SetBool("isAimBack", isAimUp);
    }
    private void ResetAimParameters()
    {
        animator.SetBool("isAimLeft", false);
        animator.SetBool("isAimRight", false);
        animator.SetBool("isAimFront", false);
        animator.SetBool("isAimBack", false);
    }
    private void UpdateAnimationParameters()
    {
        Vector2 movementDirection = (objectTransform.position - previousPosition).normalized;
        bool isMovingLeft = movementDirection.x < -0.2f;
        bool isMovingRight = movementDirection.x > 0.2f;
        bool isMovingFront = movementDirection.y < -0.2f && !isMovingLeft && !isMovingRight;
        bool isMovingBack = movementDirection.y > 0.2f && !isMovingLeft && !isMovingRight;
        bool isMoving = movementDirection.magnitude > 0.2f;
        if (isMoving)
        {
            if (!isRightMouseButtonDown)
            {
                ResetAimParameters();
            }
            isIdle = false;
        }
        else if (!isRightMouseButtonDown)
        {
            isIdle = true;
        }
        if (!animator.GetBool("isAimLeft") && !animator.GetBool("isAimRight") &&
            !animator.GetBool("isAimFront") && !animator.GetBool("isAimBack"))
        {
            animator.SetBool("isMovingFront", isMovingFront && isMoving);
            animator.SetBool("isMovingBack", isMovingBack && isMoving);
            animator.SetBool("isMovingLeft", isMovingLeft && isMoving);
            animator.SetBool("isMovingRight", isMovingRight && isMoving);
        }
        animator.SetBool("idleReturn", isIdle);
    }
    private void CheckIdleState()
    {
        Vector2 movementDirection = (objectTransform.position - previousPosition).normalized;
        bool isMoving = movementDirection.magnitude > 0.2f;
        if (!isMoving && !isRightMouseButtonDown)
        {
            isIdle = true;
        }
        else
        {
            isIdle = false;
        }
    }
}
