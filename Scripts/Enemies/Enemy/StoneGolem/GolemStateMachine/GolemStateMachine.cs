using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemStateMachine : StateMachine
{
    public Golem Golem {get;}
    
    public GolemIdleState GolemIdleState {get;set;}
    public GolemImmune1State GolemImmune1State {get;set;}
    public GolemImmune2State GolemImmune2State {get;set;}

    public GolemLaserState GolemLaserState {get;set;}
    public GolemShoot1State GolemShoot1State {get;set;}
    public GolemShoot2State GolemShoot2State {get;set;}

    public GolemThorn1State GolemThorn1State {get;set;}
    public GolemThorn2State GolemThorn2State {get;set;}

    public GolemDeathState GolemDeathState {get;set;}


    public GolemStateMachine(Golem golem)
    {
        this.Golem = golem;
        GolemIdleState = new(this);
        GolemImmune1State = new(this);
        GolemImmune2State = new(this);

        GolemLaserState = new(this);
        GolemShoot1State = new(this);
        GolemShoot2State = new(this);

        GolemThorn1State = new(this);
        GolemThorn2State = new(this);

        GolemDeathState = new(this);

    }
}
