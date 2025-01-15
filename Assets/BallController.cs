using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float jumpForce;


    public void MoveBall(Vector3 input)
    {
        if (input.y > 0)
        {
            sphereRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Jump with impluse
        }
       
        Vector3 inputXZPlane = new(input.x, 0, input.z);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed, ForceMode.Force); // move with normal force/Smooth movement
    }
}
