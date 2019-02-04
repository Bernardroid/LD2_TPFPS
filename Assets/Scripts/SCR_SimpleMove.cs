using UnityEngine;

public class SCR_SimpleMove : MonoBehaviour
{

    float jumpForce = 200f;
    bool canClimb = false;

    [Range(0.5f, 5.0f)]
    public float lookSensibility = 2.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;
    float playerSpeed = 5.0f;

    Rigidbody rb;
    public Transform cameraChild;
    public Transform respawnPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            playerSpeed = 7.5f;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            playerSpeed = 5.0f;
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;

        yaw += lookSensibility * Input.GetAxis("Mouse X");
        pitch += lookSensibility * Input.GetAxis("Mouse Y");

        cameraChild.transform.eulerAngles = new Vector3(Mathf.Clamp(-pitch, -90, 90), cameraChild.transform.eulerAngles.y, 0.0f);
        transform.eulerAngles = new Vector3(0, yaw, 0.0f);

        if (!canClimb)
            transform.Translate(x, 0, z);

        else
            transform.Translate(x, z, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Climbable"))
        {
            Debug.Log("AM IN HERE");
            canClimb = true;
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
        }
        if(other.CompareTag("Death"))
        {
            transform.position = respawnPoint.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Climbable"))
        {
            canClimb = false;
            rb.useGravity = true;
        }
    }
}