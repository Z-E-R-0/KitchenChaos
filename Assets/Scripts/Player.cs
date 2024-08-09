using System;
using UnityEngine;

public class Player : MonoBehaviour, IkitchenObjectParent
{

    public static Player Instance { get; private set; }
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInputs gameInputs;
    [SerializeField] private float interactDistance = 2f;
    private bool isWalking;
    [SerializeField] private LayerMask CounterlayerMask;
    private Vector3 lastInteractedDirection; // Fixed spelling of 'lastInteractedDirection'
    private BaseCounter selectedCounter;
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public event EventHandler OnPickedSometing;
    private KitchenObjects kitchenObjects;
    [SerializeField] private Transform kitchenObjectHoldPoint;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one Player instance found!"); // Changed Debug.Log to Debug.LogError for better error indication
            return; // Added return statement to prevent overwriting Instance
        }
        Instance = this;
    }

    private void Start()
    {
        gameInputs.OnInteractAction += GameInput_OnInteractAction;
        gameInputs.OnInteractAlternate += GameInput_OnInteractAlternateAction;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
       
            if (selectedCounter != null)
            {
                selectedCounter.Interact(this); // Fixed spelling of 'Interact'
            }

       

    }
    private void GameInput_OnInteractAlternateAction(object sender, EventArgs e)
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        if (selectedCounter != null)
        {
            selectedCounter.InteractAlternate(this); // Fixed spelling of 'Interact'
        }
    }

    private void Update()
    {
        HandleMovement(); // Fixed spelling of 'HandleMovement'
        HandleInteraction(); // Fixed spelling of 'HandleInteraction'
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleMovement() // Fixed spelling of 'HandleMovement'
    {
        Vector2 inputVector = gameInputs.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        float distance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, distance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, distance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, distance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    moveDir = Vector3.zero; // Changed to zero vector to prevent movement
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }

        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private void HandleInteraction() // Fixed spelling of 'HandleInteraction'
    {
        Vector2 inputVector = gameInputs.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInteractedDirection = moveDir; // Fixed spelling of 'lastInteractedDirection'
        }

        if (Physics.Raycast(transform.position, lastInteractedDirection, out RaycastHit raycastHit, interactDistance, CounterlayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != selectedCounter) // Changed condition to compare with selectedCounter
                {
                    SetSelectedCounter(baseCounter); // Call SetSelectedCounter only when there is a change
                }
            }
            else
            {
                SetSelectedCounter(null); // Call SetSelectedCounter to null when no counter is hit
            }
        }
        else
        {
            SetSelectedCounter(null); // Call SetSelectedCounter to null when no hit is detected
        }
    }

    private void SetSelectedCounter(BaseCounter newCounter)
    {
        if (newCounter != selectedCounter) // Added check to update only if there is a change
        {
            selectedCounter = newCounter;
            OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs { selectedCounter = selectedCounter });
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {

        return kitchenObjectHoldPoint;

    }

    public void SetkitchenObject(KitchenObjects kitchenObjects)
    {
        this.kitchenObjects = kitchenObjects;
        if (kitchenObjects != null)
        {
            OnPickedSometing?.Invoke(this, EventArgs.Empty);
        }


    }
    public KitchenObjects GetKitchenObject()
    {

        return kitchenObjects;

    }

    public void ClearKitchenObjects()
    {

        kitchenObjects = null;

    }

    public bool HasKitchenObjects()
    {
        return kitchenObjects != null;

    }
}
