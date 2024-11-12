using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;


public class SpawnCube : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn = null;
    [SerializeField]
    private LayerMask GroundLayer;



    private void Start()
    {
        InputManager.Instance.RegisterOnClickInput(OnClick, true);
        InputManager.Instance.FingerDownAction += OnFingerDown;
    }

    private void OnDestroy()
    {
        InputManager.Instance.RegisterOnClickInput(OnClick, false);
    }

    private void OnFingerDown(Vector2 screenPosition)
    {
        CubeSpawner(screenPosition);

    }

    private void OnClick(InputAction.CallbackContext callbackContext)
    {
        CubeSpawner(Input.mousePosition);
    }

    public void CubeSpawner(Vector2 screenPosition)
    {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

            bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 100000, GroundLayer);
            if (raycastHasHit && objectToSpawn != null)
            {
                Vector3 point = hitInfo.point;
                point.y += 0.5f;

                GameObject.Instantiate(objectToSpawn, point, Quaternion.identity);

            }
    }
}
