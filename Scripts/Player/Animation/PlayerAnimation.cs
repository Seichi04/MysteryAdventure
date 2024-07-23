using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Player Player {get;private set;}

    private void Start()
    {
        Player = GetComponentInParent<Player>();
    }

    public void AnimationEnterEvent()
    {
        Player.OnAnimationEnterEvent();
    }
    public void AnimationExitEvent()
    {
        Player.OnAnimationExitEvent();
    }
    public void AnimationTransitionEvent()
    {
        Player.OnAnimationTransitionEvent();
    }
}
