using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemCollider : MonoBehaviour
{
    public LayerMask MapLayer;

    public Transform CheckFront;
    public Transform CheckBack;
    public Transform CheckTop;
    public Transform CheckDown;


    public Vector2 CheckDownSize;
    public Vector2 CheckFrontSize;
    public Vector2 CheckBackSize;
    public Vector2 CheckTopSize;

    public bool IsGrounded;
    public bool IsWallTop;
    public bool IsWallFront;
    public bool IsWallBack;
    public bool IsEdge;
    private void Update()
    {
        IsGrounded = Ground;
        IsWallTop = WallTop;
        IsWallFront = WallFront;
        IsWallBack = WallBack;
    }

    public bool Ground
    {
        get =>Physics2D.OverlapBox(CheckDown.position, CheckDownSize,0f, MapLayer);
    }
    public bool WallTop
    {
        get => Physics2D.OverlapBox(CheckTop.position,CheckTopSize,0f,MapLayer);
    }
    public bool WallFront
    {
        get => Physics2D.OverlapBox(CheckFront.position, CheckFrontSize,0f, MapLayer);
    }

    public bool WallBack
    {
        get => Physics2D.OverlapBox(CheckBack.position, CheckBackSize,0f, MapLayer);
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(CheckDown.position, CheckDownSize);
        Gizmos.DrawWireCube(CheckFront.position, CheckFrontSize);
        Gizmos.DrawWireCube(CheckBack.position, CheckBackSize);
        Gizmos.DrawWireCube(CheckTop.position, CheckTopSize);
    }
}
