using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public TagLayerSO TagLayerSO;
    public LayerMask MapLayer;

    public Transform CheckFront;
    public Transform CheckBack;
    public Transform CheckTop;
    public Transform CheckDown;
    public Transform CheckEdge1;
    public Transform CheckEdge2;




    public Vector2 CheckDownSize;
    public Vector2 CheckFrontSize;
    public Vector2 CheckBackSize;
    public Vector2 CheckTopSize;
    public Vector2 CheckEdgeSize;

    public bool IsGrounded;
    public bool IsWallTop;
    public bool IsWallFront;
    public bool IsWallBack;
    public bool IsEdge;

    private void Start() {
        TagLayerSO = GetComponentInParent<Player>().TagLayerSO;
        MapLayer = TagLayerSO.MapLayer;
    }
    private void Update()
    {
        IsGrounded = Ground;
        IsWallTop = WallTop;
        IsWallFront = WallFront;
        IsWallBack = WallBack;
        if(!Edge1 && Edge2)
        {
            IsEdge = true;
        }
        else
            IsEdge = false;
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
    public bool Edge1
    {
        get => Physics2D.OverlapBox(CheckEdge1.position,CheckEdgeSize,0f, MapLayer);
    }
    public bool Edge2
    {
        get => Physics2D.OverlapBox(CheckEdge2.position,CheckEdgeSize,0f, MapLayer);
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(CheckDown.position, CheckDownSize);
        Gizmos.DrawWireCube(CheckFront.position, CheckFrontSize);
        Gizmos.DrawWireCube(CheckBack.position, CheckBackSize);
        Gizmos.DrawWireCube(CheckTop.position, CheckTopSize);
        Gizmos.DrawWireCube(CheckEdge1.position, CheckEdgeSize);
        Gizmos.DrawWireCube(CheckEdge2.position, CheckEdgeSize);
    }



}
