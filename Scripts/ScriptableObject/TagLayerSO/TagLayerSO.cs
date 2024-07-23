using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TagLayer", menuName = "Custom/TagLayer")]
public class TagLayerSO : ScriptableObject
{
    [field: Header("Tag")]
    #region Tag
    [field: SerializeField] public string PlayerTag {get; set;} = "Player";
    [field: SerializeField] public string LadderTag {get;set;} ="Ladder";
    [field: SerializeField] public string EnemyTag {get;set;} = "Enemy";
    [field: SerializeField] public string BoxDamage {get;set;} = "BoxDamage";
    [field: SerializeField] public string BulletTag {get;set;} = "Bullet";
    [field: SerializeField] public string BuffTag {get;set;} = "Buff";
    #endregion

    [field: Header("Layer")]
    #region Layer
    [field: SerializeField] public LayerMask MapLayer {get;set;}
    [field: SerializeField] public string MapLayerString {get;set;} = "Map";

    [field: SerializeField] public LayerMask EnemyTouchLayer {get;set;}
    [field: SerializeField] public string EnemyTouch {get;set;} = "EnemyTouch";

    [field: SerializeField] public LayerMask EnemyNoTouchLayer {get;set;}
    [field: SerializeField] public string EnemyNoTouch {get;set;} = "EnemyNoTouch";

    [field: SerializeField] public LayerMask PlayerLayer {get;set;}
    [field: SerializeField] public string Player {get;set;} = "Player";

    [field: SerializeField] public LayerMask PlayerNoTouchLayer {get;set;}
    [field: SerializeField] public string PlayerNoTouch {get;set;} = "PlayerNoTouch";
    #endregion
}
