using UnityEngine;
using Random = UnityEngine.Random;


public class AnimationManager : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator animator;
    private NpcMovementManager npcMovementManager;
    public float playbackSpeed;
    private float speed;

    [SerializeField]private string idleAnimName;
    [SerializeField]private string walkAnimName;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playbackSpeed = Random.Range(.6f, 1f);
        animator.speed = playbackSpeed;
        npcMovementManager = GetComponent<NpcMovementManager>();
        npcMovementManager.speed *= playbackSpeed;
    }

    private void Update()
    {
        animator.Play(rb2D.velocity == Vector2.zero ? idleAnimName : walkAnimName);
    }
}
