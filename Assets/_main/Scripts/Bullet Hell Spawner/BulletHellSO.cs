using UnityEngine;

[CreateAssetMenu(fileName = "BulletHell_", menuName = "BulletHell")]
public class BulletHellSO : ScriptableObject
{
    public int emitCount = 1;

    public int numberOfColumns = 1;

    public float bulletFireRate = 1;

    public float bulletSpinSpeed = 0;

    public float bulletSpeed = 5;

    public float bulletLifeTime = 5;

    public float bulletSize = 2;

    public Color color = Color.white;

    public Material material;

    public Sprite[] sprites;

    public int animationCycleCount = 4;

    public float colliderForce = 0;

    [Range(0, 2)] public float bounceForce = 0;

    [Range(0, 1)] public float lifetimeLoss = 0;


    public LayerMask layerToCollide;

    public float radial = 0;

    public float bulletInitialSpeedMultiplier = 1;

    public float bulletEndSpeedMultiplier = 1;
}
