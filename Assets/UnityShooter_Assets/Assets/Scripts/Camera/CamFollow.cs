using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5;

    Vector3 offset;
    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
