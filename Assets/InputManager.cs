using UnityEngine;
using UnityEngine.Events;

public class InputMonitoring : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    private bool isTouchingPlane = false; // Tracks if the sphere is touching the plane

    // Detect collision with the plane
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isTouchingPlane = true;
        }
    }

    // Detect when the sphere stops touching the plane
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isTouchingPlane = false;
        }
    }

    void Update()
    {
        Vector3 inputVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector3.forward;       
        }
         if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector3.left;
        }
         if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector3.back;
        }
         if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector3.right;
        }
       if (Input.GetKeyDown(KeyCode.Space) && isTouchingPlane)
        {
            inputVector += Vector3.up; 
        }
        OnMove?.Invoke(inputVector);
    }
}
