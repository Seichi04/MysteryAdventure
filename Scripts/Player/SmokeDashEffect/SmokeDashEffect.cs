using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeDashEffect : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnEnable() {
        
    }


    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
