using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] Canvas canvas;

    private void Update()
    {
        //canvas.transform.LookAt(Camera.main.transform.position);
        canvas.transform.rotation = Quaternion.LookRotation(canvas.transform.position - Camera.main.transform.position);
    }

}
