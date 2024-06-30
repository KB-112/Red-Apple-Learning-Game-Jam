using UnityEngine;

public class AnimationTester : MonoBehaviour
{
    private Animator animator;

    public AnimationState animationState;

    // Animation States
    private const string MUSKETTER_DASH_ATTACK = "Musketter_dash_attack";
    private const string MUSKETTER_DEAD = "Musketter_dead";
    private const string MUSKETTER_IDLE = "Musketter_idle";
    private const string MUSKETTER_JUMP = "Musketter_jump";
    private const string MUSKETTER_QUICK_ATTACK = "Musketter_quick_attack";
    private const string MUSKETTER_RUN = "Musketter_run";
    private const string MUSKETTER_SLASH_ATTACK = "Musketter_slash_attack";
    private const string MUSKETTER_WALK = "Musketter_walk";

    public enum AnimationState
    {
        MusketterDashAttack,
        MusketterDead,
        MusketterIdle,
        MusketterJump,
        MusketterQuickAttack,
        MusketterRun,
        MusketterSlashAttack,
        MusketterWalk
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayAnimation(animationState);
    }

    private void PlayAnimation(AnimationState state)
    {
        switch (state)
        {
            case AnimationState.MusketterDashAttack:
                animator.Play(MUSKETTER_DASH_ATTACK);
                break;
            case AnimationState.MusketterDead:
                animator.Play(MUSKETTER_DEAD);
                break;
            case AnimationState.MusketterIdle:
                animator.Play(MUSKETTER_IDLE);
                break;
            case AnimationState.MusketterJump:
                animator.Play(MUSKETTER_JUMP);
                break;
            case AnimationState.MusketterQuickAttack:
                animator.Play(MUSKETTER_QUICK_ATTACK);
                break;
            case AnimationState.MusketterRun:
                animator.Play(MUSKETTER_RUN);
                break;
            case AnimationState.MusketterSlashAttack:
                animator.Play(MUSKETTER_SLASH_ATTACK);
                break;
            case AnimationState.MusketterWalk:
                animator.Play(MUSKETTER_WALK);
                break;
        }
    }
}
