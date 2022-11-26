using UnityEngine;

// In this example, we have a Particle System emitting green particles; we then emit and override some properties every 2 seconds.
public class BulletHellSpawner : MonoBehaviour
{
    [SerializeField] ParticleSystem system;

    [SerializeField] int emitCount = 1;

    [SerializeField] int numberOfColumns = 1;

    [SerializeField] float bulletFireRate = 1;

    [SerializeField] float bulletSpinSpeed;

    [SerializeField] float bulletSpeed = 5;

    [SerializeField] float bulletLifeTime = 5;

    [SerializeField] float bulletSize = 2;

    [SerializeField] Color color = Color.white;

    [SerializeField] Material material;

    [SerializeField] Sprite[] sprites;

    [SerializeField] int animationCycleCount = 4;

    [SerializeField] private float colliderForce;

    [SerializeField] LayerMask layerToCollide;

    readonly int maxParticles = 9999999;

    private float angle;

    private void Start()
    {
        GenerateBulletHell();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, bulletSpinSpeed * Time.fixedTime);
    }
    void GenerateBulletHell()
    {
        angle = 360 / numberOfColumns;

        for (int i = 0; i < numberOfColumns; i++)
        {
            //// A simple particle material with no texture.
            //Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");

            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = transform;
            go.transform.position = transform.position;

            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = material;

            var mainModule = system.main;
            mainModule.startColor = color;
            mainModule.startSize = bulletSize;
            mainModule.startLifetime = bulletLifeTime;
            mainModule.startSpeed = bulletSpeed;
            mainModule.maxParticles = maxParticles;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            var emission = system.emission;
            emission.enabled = false;

            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;

            var texture = system.textureSheetAnimation;
            texture.enabled = true;
            texture.mode = ParticleSystemAnimationMode.Sprites;
            texture.cycleCount = animationCycleCount;
            for (int sprite = 0; sprite < sprites.Length; sprite++)
            {
                texture.AddSprite(sprites[sprite]);
            }

            var collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.colliderForce = colliderForce;
            collision.collidesWith = layerToCollide;

            var trigger = system.trigger;
            trigger.enabled = true;
            trigger.enter = ParticleSystemOverlapAction.Callback;
            trigger.inside = ParticleSystemOverlapAction.Kill;
        }
        // Every 2 secs we will emit.
        InvokeRepeating(nameof(DoEmit), 0f, bulletFireRate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();

            //Only when need to override, not right now
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            //var emitParams = new ParticleSystem.EmitParams
            //{
            //    startColor = color,
            //    startSize = size,
            //    startLifetime = lifeTime,

            //};
            system.Emit(emitCount);

        }
    }
}