using UnityEngine;
public class Glider : MonoBehaviour
{
    [SerializeField]
    private float m_FallSpeed = 5f;

    /// Flag to check if gliding
    public bool IsGliding { get; set; } = false;

    private Rigidbody2D m_Rigidbody2D = null;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        //Is Gliding = true
        IsGliding = true;
    }

    void Update()
    {
        if (IsGliding && m_Rigidbody2D.velocity.y < 0f && Mathf.Abs(m_Rigidbody2D.velocity.y) > m_FallSpeed)
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Sign(m_Rigidbody2D.velocity.y) * m_FallSpeed);
    }

    public void StartGliding()
    {
        IsGliding = true;
    }

    public void StopGliding()
    {
        IsGliding = false;
    }
}