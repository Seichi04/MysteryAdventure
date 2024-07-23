using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPortal : MonoBehaviour
{
    public StartPortal StartPortal;

    public GameObject Player;

    private Animator animator;

    private void OnEnable() {
        //animator = GetComponent<Animator>();
        Player = StartPortal.Player;
    }

    public void Appear()
    {
        Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Player.SetActive(true);
    }
}
