using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // instance of MapController
    public MapController mapController;
    public Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapController = GameObject.Find("Controllers").GetComponent<MapController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = this.transform.position;

        // basic x, y movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            targetPosition += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetPosition += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            targetPosition += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetPosition += new Vector3(1, 0, 0);
        }

        // Check if the target position is passable
        if (mapController.isPassable((int)targetPosition.x, (int)targetPosition.y))
        {
            this.transform.position = targetPosition;
            // move the camera to follow the player
            camera.transform.position = new Vector3(targetPosition.x, targetPosition.y, camera.transform.position.z);
        }
    }
}
