using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrosshairTracker : MonoBehaviour
{
    [SerializeField] Transform shootPointPosition;
    [SerializeField] float transAngleMax = 0.07f;
    private Vector3 offset;
    private Vector3 temp;
    private Vector3 point;
    private float transAngleMin;

    private void Awake()
    {
        offset = shootPointPosition.position - Camera.main.transform.position;
        transAngleMin = Mathf.Sqrt(1 - Mathf.Pow(1 - transAngleMax, 2));
    }


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
        if (Mathf.Abs(mousePos.x) < 1 - transAngleMax && Mathf.Abs(mousePos.z) > transAngleMin)
        {
            if (temp.x <= 0 && temp.z > 0 || temp.x > 0 && temp.z <= 0)
            {
                temp = -temp;
            }
            if (transform.rotation.eulerAngles.y * Quaternion.FromToRotation(Vector3.right, temp).eulerAngles.y < 0) temp = -temp;
            Debug.Log($"по темпу {point}     {mousePos}        {temp}");
            transform.rotation = Quaternion.FromToRotation(Vector3.right, temp);
        }
        else
        {
            if (transform.rotation.eulerAngles.y * Quaternion.FromToRotation(Vector3.right, mousePos).eulerAngles.y < 0) mousePos = -mousePos;
            Debug.Log($"по позиции мыши   {point}     {mousePos}        {temp}");
            transform.rotation = Quaternion.FromToRotation(Vector3.right, mousePos);
        }


    }
}
