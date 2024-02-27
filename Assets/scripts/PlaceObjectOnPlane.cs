/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private Vector2 touchPosition;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool objectPlaced = false;

    private float initialDistance;
    private Vector3 initialScale;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition)) return;

        if (raycastManager.Raycast(touchPosition, hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
            }
            /*else
            { 
                spawnedObject.transform.position = hitPose.position;
            }*/
/*}

if (Input.touchCount == 2)
{
    var touchZero = Input.GetTouch(0);
    var touchOne = Input.GetTouch(1);
    // if any one of touchzero or touchOne
    if (touchZero.phase == TouchPhase.Ended || touchZero.phase == TouchPhase.Canceled ||
        touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
{
        return; // basically do nothing
    }
    if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
    {
        initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
        initialScale = spawnedObject.transform.localScale;
    }
    else // if touch is moved
    {
        var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
        if (Mathf.Approximately(initialDistance, 0))
        {
            return; // do nothing if it can be ignored wh
        }
        var factor = currentDistance / initialDistance;
        spawnedObject.transform.localScale = initialScale * factor;
    }
}
}

}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField] private GameObject objectToPlace;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;
    private Vector2 touchStartPos;
    private Vector3 lastTouchPosition;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private bool objectPlaced = false;
    private float initialDistance;
    private Vector3 initialScale;
    [SerializeField]public GameObject Canva;

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!objectPlaced)
        {
            if (TryGetTouchPosition(out Vector2 touchPosition) && raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);

                    objectPlaced = true;
                    Canva.SetActive(true);
                }
            }
        }

        if (spawnedObject != null)
        {
            if (Input.touchCount == 1)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                    lastTouchPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    Vector2 touchDelta = new Vector2(touch.position.x,lastTouchPosition.y - lastTouchPosition.y);
                    lastTouchPosition = touch.position;
                    float rotationSpeed = 0.01f;
                    spawnedObject.transform.Rotate(Vector3.up, -touchDelta.x * rotationSpeed);
                }
            }

            if (Input.touchCount == 2)
            {
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);

                if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
                {
                    var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    if (Mathf.Approximately(initialDistance, 0))
                    {
                        return;
                    }
                    var factor = currentDistance / initialDistance;
                    spawnedObject.transform.localScale = initialScale * factor;
                }

                if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
                {
                    initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                    initialScale = spawnedObject.transform.localScale;
                }
            }
        }
    }
}



