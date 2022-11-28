using UnityEngine;
using ScriptableObjects;
using System.Collections;
// In this example, we have a Particle System emitting green particles; we then emit and override some properties every 2 seconds.
public class BulletHellSpawner : MonoBehaviour
{

    ParticleSystem system;

    [SerializeField] BulletHellSO bulletHellSO;

    private WaitForSeconds waitForTimer;

    readonly int maxParticles = 9999999;

    private float angle;

    private void Start()
    {
        waitForTimer = new WaitForSeconds(bulletHellSO.bulletFireRate);
        GenerateBulletHell();
    }
    private IEnumerator ActivateOnTimer()
    {
        while (true)
        {
            yield return waitForTimer;
            DoEmit();
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, bulletHellSO.bulletSpinSpeed * Time.fixedTime);
    }
    void GenerateBulletHell()
    {
        angle = 360 / bulletHellSO.numberOfColumns;

        for (int i = 0; i < bulletHellSO.numberOfColumns; i++)
        {
            //// A simple particle material with no texture.
            //Material particleMaterial = material;

            // Create a green Particle System.
            GameObject go = new GameObject("Particle System");

            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = transform;
            go.transform.position = transform.position;

            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = bulletHellSO.material;

            ParticleSystem.MainModule mainModule = system.main;
            mainModule.startColor = bulletHellSO.color;
            mainModule.startSize = bulletHellSO.bulletSize;
            mainModule.startLifetime = bulletHellSO.bulletLifeTime;
            mainModule.startSpeed = bulletHellSO.bulletSpeed;
            mainModule.maxParticles = maxParticles;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            ParticleSystem.EmissionModule emission = system.emission;
            emission.enabled = false;

            ParticleSystem.ShapeModule shape = system.shape;
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;


            ParticleSystem.VelocityOverLifetimeModule velocityOverLifetime = system.velocityOverLifetime;
            velocityOverLifetime.enabled = true;
            velocityOverLifetime.radial = bulletHellSO.radial;

            //AnimationCurve curve = new AnimationCurve();
            //curve.AddKey(0.0f, 0.0f);
            //curve.AddKey(1.0f, 1.0f);

            //ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(1.0f, curve);

            //velocityOverLifetime.speedModifier = minMaxCurve;
            AnimationCurve curve = new AnimationCurve();
            curve.AddKey(0, bulletHellSO.bulletInitialSpeedMultiplier);
            curve.AddKey(1, bulletHellSO.bulletEndSpeedMultiplier);
            velocityOverLifetime.speedModifier = new ParticleSystem.MinMaxCurve(1, curve);



            ParticleSystem.TextureSheetAnimationModule texture = system.textureSheetAnimation;
            texture.enabled = true;
            texture.mode = ParticleSystemAnimationMode.Sprites;
            texture.cycleCount = bulletHellSO.animationCycleCount;
            for (int sprite = 0; sprite < bulletHellSO.sprites.Length; sprite++)
            {
                texture.AddSprite(bulletHellSO.sprites[sprite]);
            }

            ParticleSystem.CollisionModule collision = system.collision;
            collision.enabled = true;
            collision.type = ParticleSystemCollisionType.World;
            collision.mode = ParticleSystemCollisionMode.Collision2D;
            collision.colliderForce = bulletHellSO.colliderForce;
            collision.collidesWith = bulletHellSO.layerToCollide;

            ParticleSystem.TriggerModule trigger = system.trigger;
            trigger.enabled = true;
            trigger.enter = ParticleSystemOverlapAction.Callback;
            trigger.inside = ParticleSystemOverlapAction.Kill;
        }
        // Every 2 secs we will emit.
        //InvokeRepeating(nameof(DoEmit), 0f, bulletHellSO.bulletFireRate);
        StartCoroutine(ActivateOnTimer());
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
            system.Emit(bulletHellSO.emitCount);

        }
    }
}