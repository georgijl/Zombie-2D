using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float offset = 3.6f;

    private Transform cameraTransform;

	// Use this for initialization
	void Start ()
    {
        cameraTransform = Camera.main.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 newPosition = cameraTransform.position;
        newPosition.x = playerTransform.position.x + offset;
        cameraTransform.position = newPosition;
	}
}
