using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class StartPortal : MonoBehaviour
{
    public GameObject EndPortal;

    public bool CanTeleport;
    public GameObject Player;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    public Collider2D ColliderEnd;
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        CanTeleport = false;
    }

    private void Update() {
        if(CanTeleport)
        {
            Teleport();
            EndPortal.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Player = other.transform.parent.gameObject;
            Player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Player.SetActive(false);
            animator.SetTrigger("Disappear");
        }
    }

    public void AppearSignal()
    {
        CanTeleport = true;
    }

    public void Teleport()
    {
        cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().enabled = false;
        Player.transform.position = EndPortal.transform.position;
        cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().m_BoundingShape2D = ColliderEnd;
        cinemachineVirtualCamera.GetComponent<CinemachineConfiner2D>().enabled = true;
        CanTeleport = false;
    }
    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
