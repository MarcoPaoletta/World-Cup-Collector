using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeIconAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OnSwipeIconRightAnimationFinished()
    {
        animator.Play("SwipeIconLeft");
    }
}