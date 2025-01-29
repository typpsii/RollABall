using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float rollSpeed = 2f;
    [SerializeField] private float jumpForce = 10f;
    private bool canJump;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (canJump)
            {
                sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = false;
            }

        }

        Vector3 zyxInput = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(zyxInput * rollSpeed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
