using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float height;

    [SerializeField] private float smoothness;

    private float xPosition;
    // Start is called before the first frame update
    void Start()
    {
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 CameraPosition = Vector3.zero;
         CameraPosition.x = xPosition;
         CameraPosition.y = height;
         CameraPosition.z = Mathf.Lerp(transform.position.z, target.position.z, smoothness * Time.deltaTime);

         transform.position = CameraPosition;

    }
}
