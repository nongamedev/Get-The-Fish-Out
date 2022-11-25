using UnityEngine;

// In this example, we have a Particle System emitting green particles; we then emit and override some properties every 2 seconds.
public class BulletHellSpawner : MonoBehaviour
{
    [SerializeField] private int numberOfColumns;

    [SerializeField] private float speed;

    [SerializeField] private Sprite sprite;

    [SerializeField] private Color color;

    [SerializeField] private float lifeTime;

    [SerializeField] private float fireRate;

    [SerializeField] private float size;

    [SerializeField] private Material material;

    [SerializeField] private ParticleSystem system;

    private float angle;

    private void Start()
    {
        GenerateBulletHell();
    }
    void GenerateBulletHell()
    {
        angle = 360 / numberOfColumns;
        for (int i = 0; i < numberOfColumns; i++)
        {
            // A simple particle material with no texture.
            Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");

            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = transform;
            go.transform.position = transform.position;

            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
            mainModule.startSpeed = speed;

            var emission = system.emission;
            emission.enabled = false;

            var shape = system.shape;
            shape.enabled = true;
            shape.shapeType = ParticleSystemShapeType.Sprite;
            shape.sprite = null;

            var texture = system.textureSheetAnimation;
            texture.enabled = true;
            texture.mode = ParticleSystemAnimationMode.Sprites;
            texture.AddSprite(sprite);
        }
        // Every 2 secs we will emit.
        InvokeRepeating(nameof(DoEmit), 0f, fireRate);
    }

    void DoEmit()
    {
        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams
            {
                startColor = color,
                startSize = size,
                startLifetime = lifeTime,

            };
            system.Emit(emitParams, 10);

        }
    }
}