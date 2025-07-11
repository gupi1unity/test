using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera
{
    private Camera _camera;
    private float _distance;

    public RaycastCamera(Camera camera, float distance)
    {
        _camera = camera;
        _distance = distance;
    }

    public bool CreateRay<T>(out T findedObject)
    {
        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(_camera.ScreenToWorldPoint(Input.mousePosition), _camera.transform.forward * _distance, Color.red);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, _distance))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<T>(out T obstacle))
            {
                Debug.DrawRay(_camera.ScreenToWorldPoint(Input.mousePosition), _camera.transform.forward * _distance, Color.green);
                findedObject = obstacle;
                return true;
            }
        }

        findedObject = default(T);
        return false;
    }
}
