using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float fastMultiplier = 3f;
    [SerializeField] float sensitivity = 2f;

    [Header("Vertical")]
    [SerializeField] float scrollSpeed = 5f;

    float _pitch;
    float _yaw;

    void Start()
    {
        Vector3 euler = transform.eulerAngles;
        _yaw = euler.y;
        _pitch = euler.x;
        if (_pitch > 180f) _pitch -= 360f;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        float speed = moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? fastMultiplier : 1f);

        if (Input.GetMouseButton(1))
        {
            _yaw += Input.GetAxis("Mouse X") * sensitivity;
            _pitch -= Input.GetAxis("Mouse Y") * sensitivity;
            _pitch = Mathf.Clamp(_pitch, -89f, 89f);
            transform.rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        }

        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) move += transform.forward;
        if (Input.GetKey(KeyCode.S)) move -= transform.forward;
        if (Input.GetKey(KeyCode.D)) move += transform.right;
        if (Input.GetKey(KeyCode.A)) move -= transform.right;
        if (Input.GetKey(KeyCode.E)) move += Vector3.up;
        if (Input.GetKey(KeyCode.Q)) move -= Vector3.up;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f) move += Vector3.up * Mathf.Sign(scroll);

        if (move.sqrMagnitude > 0f)
        {
            move.Normalize();
            float upDown = move.y;
            Vector3 horizontal = move;
            horizontal.y = 0f;
            if (horizontal.sqrMagnitude > 0f) horizontal.Normalize();
            transform.position += (horizontal.x * transform.right + horizontal.z * transform.forward) * speed * dt;
            transform.position += Vector3.up * (upDown * (Mathf.Abs(scroll) > 0.001f ? scrollSpeed : speed) * dt);
        }
    }
}
