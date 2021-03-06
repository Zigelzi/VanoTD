using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputManager : MonoBehaviour
{
    [SerializeField] float panSpeed = 20f;
    [SerializeField] float zoomSpeed = 20f;
    [SerializeField][Tooltip("In pixels")] float panBorderThickness = 100f;

    // Controls
    KeyCode upKey = KeyCode.W;
    KeyCode downKey = KeyCode.S;
    KeyCode leftKey = KeyCode.A;
    KeyCode rightKey = KeyCode.D;

    enum Direction { Up, Down, Left, Right }

    // Update is called once per frame
    void Update()
    {
        ReadKeyboardMovementInput();
        if (MouseWithinBounds())
        {
            ReadMouseMovementInput();
            ZoomCamera();
        }
    }

    void ReadKeyboardMovementInput()
    {
        if (Input.GetKey(upKey))
        {
            MoveCamera(Direction.Up);
        }
        else if (Input.GetKey(downKey))
        {
            MoveCamera(Direction.Down);
        };

        if (Input.GetKey(leftKey))
        {
            MoveCamera(Direction.Left);
        } 
        else if (Input.GetKey(rightKey)) {
            MoveCamera(Direction.Right);
        };
    }

    void MoveCamera(Direction movementDirection)
    {
        Vector3 cameraPosition = transform.position;
        if (movementDirection == Direction.Up)
        {
            cameraPosition.z += panSpeed * Time.deltaTime;
        }
        if (movementDirection == Direction.Down)
        {
            cameraPosition.z -= panSpeed * Time.deltaTime;
        }
        if (movementDirection == Direction.Left)
        {
            cameraPosition.x -= panSpeed * Time.deltaTime;
        }
        if (movementDirection == Direction.Right)
        {
            cameraPosition.x += panSpeed * Time.deltaTime;
        }

        cameraPosition = ClampCameraMovement(cameraPosition);
        transform.position = cameraPosition;
    }

    Vector3 ClampCameraMovement(Vector3 cameraPosition)
    {
        // Play area isn't centered to 0,0 so take the offset into account when clamping the camera position
        float leftBoundary = 0f; // Limit on X axis
        float rightBoundary = 200f; // Limit on X axis
        float topBoundary = 200f; // Limit on Z axis
        float bottomBoundary = -50f; // Limit on Z axis
        Vector3 clampedCameraPosition = cameraPosition;

        clampedCameraPosition.x = Mathf.Clamp(cameraPosition.x, leftBoundary, rightBoundary);
        clampedCameraPosition.z = Mathf.Clamp(cameraPosition.z, bottomBoundary, topBoundary);

        return clampedCameraPosition;
    }

    bool MouseWithinBounds()
    {
        if (Input.mousePosition.y >= 0 &&
            Input.mousePosition.y <= Screen.height &&
            Input.mousePosition.x >= 0 &&
            Input.mousePosition.x <= Screen.width)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }

    void ReadMouseMovementInput()
    {
        if (MouseAtScrollBorder(Direction.Up))
        {
            MoveCamera(Direction.Up);
        }
        else if (MouseAtScrollBorder(Direction.Down))
        {
            MoveCamera(Direction.Down);
        };

        if (MouseAtScrollBorder(Direction.Left))
        {
            MoveCamera(Direction.Left);
        }
        else if (MouseAtScrollBorder(Direction.Right))
        {
            MoveCamera(Direction.Right);
        };
    }

    bool MouseAtScrollBorder(Direction panDirection)
    {
        if (panDirection == Direction.Up)
        {
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (panDirection == Direction.Down)
        {
            if (Input.mousePosition.y <= panBorderThickness)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (panDirection == Direction.Left)
        {
            if (Input.mousePosition.x <= panBorderThickness)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        if (panDirection == Direction.Right)
        {
            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    void ZoomCamera()
    {
        Vector3 cameraPosition = transform.position;

        float scroll = Input.GetAxis("Mouse Wheel");
        float zoomSpeedAmplification = 200f; // Scroll speed needs to be amplified so that camera moves in sensible speed
        cameraPosition.y -= scroll * zoomSpeed * zoomSpeedAmplification * Time.deltaTime;
        cameraPosition = ClampCameraZoom(cameraPosition);
        transform.position = cameraPosition;
    }

    Vector3 ClampCameraZoom(Vector3 cameraPosition)
    {
        float minScrollLimit = 30f;
        float maxScrollLimit = 120f;
        Vector3 clampedCameraPosition = cameraPosition;
        clampedCameraPosition.y = Mathf.Clamp(cameraPosition.y, minScrollLimit, maxScrollLimit);
        return clampedCameraPosition;
    }
}
