using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MuskeetAnimationState", menuName = "Animation/AnimationState")]
public class MuskettenAnim : ScriptableObject
{
   
    private static readonly string[] animationNames = {
        "Musketter_dash_attack",
        "Musketter_dead",
        "Musketter_idle",
        "Musketter_jump",
        "Musketter_quick_attack",
        "Musketter_run",
        "Musketter_slash_attack",
        "Musketter_walk"
    };
    public string GetAnimationName(AnimationState state)
    {
        int index = (int)state;
        return animationNames[index];
    }

}
public enum AnimationState
{
    MusketterDashAttack =0,
    MusketterDead =1,
    MusketterIdle =2,
    MusketterJump =3,
    MusketterQuickAttack =4,
    MusketterRun =5,
    MusketterSlashAttack=6,
    MusketterWalk=7
}
