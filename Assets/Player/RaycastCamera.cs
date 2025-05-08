using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera
{
    private Camera _camera;

    public RaycastCamera(Camera camera)
    {
        _camera = camera;
    }

    public bool CreateRay<T>(float distance, out T findedObject)
    {
        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_camera.ScreenToWorldPoint(Input.mousePosition), _camera.transform.forward * distance, Color.red);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, distance))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<T>(out T obstacle))
            {
                Debug.DrawRay(_camera.ScreenToWorldPoint(Input.mousePosition), _camera.transform.forward * distance, Color.green);
                findedObject = obstacle;
                return true;
            }
        }

        findedObject = default(T);
        return false;
    }
}
