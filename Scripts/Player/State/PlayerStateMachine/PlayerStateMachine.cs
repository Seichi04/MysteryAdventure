using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player {get;}
    public PlayerReusableData ReusableData {get;}


    //Airborne State
    public EdgeState EdgeState{get;set;}
    public FallState FallState{get;set;}
    public JumpState JumpState{get;set;}
    public LadderGrabState LadderGrabState{get;set;}
    public WallSlideState WallSlideState{get;set;}

    //Grounded State
    public CrouchState CrouchState{get;set;}
    public DashState DashState{get;set;}
    public IdleState IdleState{get;set;}
    public RunState RunState{get;set;}
    public SlideState SlideState{get;set;}

    //Attack State
    public NomalAttackState NomalAttackState{get;set;}
    public DashAttackState DashAttackState{get;set;}

    //Hit State
    public DeathState DeathState{get;set;}
    public HurtState HurtState{get;set;}

    public PlayerStateMachine(Player player)
    {
        this.Player = player;
        ReusableData = new PlayerReusableData();

        EdgeState = new EdgeState(this);
        FallState = new FallState(this);
        JumpState = new JumpState(this);
        LadderGrabState = new LadderGrabState(this);
        WallSlideState = new WallSlideState(this);

        CrouchState = new CrouchState(this);
        DashState = new DashState(this);
        IdleState = new IdleState(this);
        RunState = new RunState(this);
        SlideState = new SlideState(this);

        NomalAttackState = new NomalAttackState(this);
        DashAttackState = new DashAttackState(this);

        DeathState = new DeathState(this);
        HurtState = new HurtState(this);
    }
}
