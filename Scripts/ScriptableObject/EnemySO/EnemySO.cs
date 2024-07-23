using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Custom/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public Vector2 KnockbackForce{get;private set;} = new Vector2(5f,20f);
    [field: SerializeField] public Vector2 KnockbackForceAirborne{get;private set;} = new Vector2(10f,10f);
    [field: SerializeField] public float TimeKnockbackAirborne {get;private set;} = 0.5f;

    [field: SerializeField] public SkeletonData SkeletonData{get;private set;}
    [field: SerializeField] public FlyEyeData FlyEyeData{get;private set;}
    [field: SerializeField] public LizardData LizardData{get;private set;}
    [field: SerializeField] public FireSkullData FireSkullData{get;private set;}
    [field: SerializeField] public OrcData OrcData{get;private set;}
    [field: SerializeField] public GolemData GolemData {get;private set;}
    [field: SerializeField] public FlyDemonData FlyDemonData {get;private set;}
}