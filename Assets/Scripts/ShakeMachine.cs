
using EZCameraShake;
using UnityEngine;

public class ShakeMachine : MonoBehaviour
{
    private static ShakeMachine _instance;
    public static ShakeMachine Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public void ShakeOnce(float magnitude = 2f, float roughness = 10f, float fadeInTime = 0f, float fadeOutTime = 5f)
    {
        CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
    }
}
