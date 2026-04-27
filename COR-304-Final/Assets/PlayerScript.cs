using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] Camera playerCamera;
    [SerializeField] float sens = 100f;
    [SerializeField] float moveSpeed = 1.0f;

    float xRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(InputSubscription.Instance.LookInput);

        float mouseX = InputSubscription.Instance.LookInput.x * sens * Time.deltaTime;

        float mouseY = InputSubscription.Instance.LookInput.y * sens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -50, 50);

        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        this.transform.Rotate(Vector3.up * mouseX);
        
        
        
        this.GetComponent<Rigidbody>().linearVelocity = transform.TransformDirection( new Vector3(InputSubscription.Instance.MoveInput.x * moveSpeed, 0, InputSubscription.Instance.MoveInput.y * moveSpeed));

    }
}
