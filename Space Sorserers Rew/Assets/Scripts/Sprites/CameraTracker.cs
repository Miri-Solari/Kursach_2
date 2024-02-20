using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    private Vector3 Gaaay;

    private void FixedUpdate()
    {
        //canvas.transform.LookAt(Camera.main.transform.position); Quaternion.LookRotation(canvas.transform.position - Camera.main.transform.position);
        Gaaay = canvas.transform.position - Camera.main.transform.position;
        canvas.transform.rotation = Quaternion.LookRotation(Gaaay);
    }

}
