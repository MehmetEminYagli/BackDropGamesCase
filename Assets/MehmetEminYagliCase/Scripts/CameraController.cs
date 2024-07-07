using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera fpsCamera;
    public Camera tpsCamera;
    public Transform character;

    public float transitionSpeed = 5.0f;
    public Vector3 fpsOffset = new Vector3(0f, 1.5f, 0f);
    public Vector3 tpsOffset = new Vector3(-6f, 6f, -6f);
    private Quaternion tpsRotation = Quaternion.Euler(45f, 45f, 0f);

    private bool isFpsView = true;

    void Start()
    {
        fpsCamera.enabled = true;
        tpsCamera.enabled = false;

        tpsCamera.transform.position = character.position + tpsOffset;
        tpsCamera.transform.rotation = tpsRotation;
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    SwitchCameras();
        //}

        if (isFpsView)
        {
            fpsCamera.transform.position = character.position + fpsOffset;
            fpsCamera.transform.rotation = character.rotation;
        }
        else
        {
            Vector3 desiredPosition = character.position + tpsOffset;
            tpsCamera.transform.position = Vector3.Lerp(tpsCamera.transform.position, desiredPosition, Time.deltaTime * transitionSpeed);
            tpsCamera.transform.rotation = tpsRotation;
        }
    }

    public void SwitchCameras()
    {
        fpsCamera.enabled = !fpsCamera.enabled;
        tpsCamera.enabled = !tpsCamera.enabled;
        isFpsView = !isFpsView;

        if (!isFpsView)
        {
            tpsCamera.transform.position = character.position + tpsOffset;
            tpsCamera.transform.rotation = tpsRotation;
        }
    }
}
