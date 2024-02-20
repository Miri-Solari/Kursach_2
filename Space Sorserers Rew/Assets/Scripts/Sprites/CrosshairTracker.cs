using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrosshairTracker : MonoBehaviour
{
    [SerializeField] Transform shootPointPosition;
    private Vector3 offset;
    private Vector3 temp;
    private Vector3 point;

    private void Awake()
    {
        offset = shootPointPosition.position - Camera.main.transform.position;
    }
    //private void Update()
    //{
    //    GunRotator(Input.mousePosition);
    //}

    public void GunRotator(Vector3 mousePos)
    {
        
            point = (shootPointPosition.position - Camera.main.transform.position - offset).normalized;
            mousePos.x /= Screen.width;
            mousePos.y /= Screen.height;
            mousePos -= Vector3.one * 0.5f;
            mousePos.z = mousePos.y;
            mousePos.y = 0;
            mousePos = mousePos.normalized;
            temp = point + mousePos;
            temp.y = temp.x;
            temp.x = temp.z;
            temp.z = -temp.y;
            temp.y = 0;
        if (temp.magnitude > 0.1f )
        {
            if (temp.x <= 0 && temp.z > 0 || temp.x > 0 && temp.z <= 0)
            {
                temp = -temp;
            }
            Debug.Log($"{point}     {mousePos}        {temp}");
            transform.rotation = Quaternion.FromToRotation(Vector3.right, temp);
        }
        else
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.right, mousePos);
        }
        
        
    }
}
