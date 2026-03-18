using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 10f;
    Vector2 moveInput;

    // how far from the screen edges the player is allowed to go
    [SerializeField] float paddingLeft = 0.5f;
    [SerializeField] float paddingRight = 0.5f;
    [SerializeField] float paddingTop = 0.5f;
    [SerializeField] float paddingBottom = 0.5f;

    float minX, maxX, minY, maxY;

    void Start()
    {
        // calculate world-space bounds from camera once at start
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 topRight   = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        minX = bottomLeft.x + paddingLeft;
        maxX = topRight.x   - paddingRight;
        minY = bottomLeft.y + paddingBottom;
        maxY = topRight.y   - paddingTop;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        // move normally
        Vector3 delta = (Vector3)moveInput * speed * Time.deltaTime;
        Vector3 newPos = transform.position + delta;

        // clamp to camera bounds
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;
    }
}