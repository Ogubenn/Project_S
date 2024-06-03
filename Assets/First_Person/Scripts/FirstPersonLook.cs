using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    [SerializeField]
    Transform armTransform; // Kolu temsil eden transform

    public float sensitivity = 2;
    public float smoothing = 1.5f;

    public float minVerticalAngle = -90f; // Minimum vertical angle
    public float maxVerticalAngle = 90f;  // Maximum vertical angle

    Vector2 velocity;
    Vector2 frameVelocity;

    private Quaternion initialArmRotation;

    void Reset()
    {
        // Get the character from the FirstPersonMovement in parents.
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;

        // Store the initial rotation of the arm
        if (armTransform != null)
        {
            initialArmRotation = armTransform.localRotation;
        }
    }

    void Update()
    {
        // Get smooth velocity.
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity;

        // Clamp the vertical velocity to stay within the specified range
        velocity.y = Mathf.Clamp(velocity.y, minVerticalAngle, maxVerticalAngle);

        // Rotate camera up-down and controller left-right from velocity.
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);

        // Rotate the arm to match the camera's vertical rotation, without changing its position
        if (armTransform != null)
        {
            armTransform.localRotation = initialArmRotation * Quaternion.AngleAxis(-velocity.y, Vector3.right);
        }
    }
}
