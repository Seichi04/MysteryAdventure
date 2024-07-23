using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemShoot2State : GolemState
{
    public GolemShoot2State(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        GolemReusableData.CurrentAttack = Golem.EnemySO.GolemData.AttackIdle;
        StartAnimation(Golem.Shoot2Animation);
        GolemReusableData.IsAttackEnd = false;
        if(Golem.transform.position.x < Golem.PlayerTransform.position.x)
        {
            ChangeRotationWhileVelocityZero(1);
        }
        else
        {
            ChangeRotationWhileVelocityZero(-1);
        }
    }

    public override void Update()
    {

        if(GolemReusableData.IsAttackEnd)
        {
            OnIdle();
        }
        else
        {
            Golem.Rigidbody2D.velocity = new Vector2(0f, 0f); 
        }
    }
    public override void Exit()
    {
        StopAnimation(Golem.Shoot2Animation);
        base.Exit();
    }
    public override void OnAnimationTransitionEvent()
    {
        ShootBullet(35);
    }

    public override void OnAnimationExitEvent()
    {
        GolemReusableData.IsAttackEnd = true;
    }

    private void ShootBullet(int quantity =1)
    {
        AudioManager.Instance.PlayStoneGolemShootAudio(Golem.audioSource);
        List<GameObject> bullets = new();
        int offset = 10;
        bullets = ObjectPool.instance.GetListPooledObject(Golem.BulletName,quantity);
        //Debug.LogError(bullets.Count);

        for(int i=1;i<=quantity;i++)
        {
            int temp = i/2;
            if(!GolemReusableData.IsRight)
            {
                if(i %2 ==0)
                    bullets[i-1].transform.eulerAngles = new Vector3(bullets[i-1].transform.eulerAngles.x,bullets[i-1].transform.eulerAngles.y,180 + offset* temp);
                else
                    bullets[i-1].transform.eulerAngles = new Vector3(bullets[i-1].transform.eulerAngles.x,bullets[i-1].transform.eulerAngles.y,180 - offset* temp);
            }
            else
            {
                if(i %2 ==0)
                    bullets[i-1].transform.eulerAngles = new Vector3(bullets[i-1].transform.eulerAngles.x,bullets[i-1].transform.eulerAngles.y,0 - offset * temp);
                else
                    bullets[i-1].transform.eulerAngles = new Vector3(bullets[i-1].transform.eulerAngles.x,bullets[i-1].transform.eulerAngles.y,0 + offset * temp);
            }
        }
        GameObject bullet = ObjectPool.instance.GetPooledObject(Golem.BulletName);
        if(!GolemReusableData.IsRight)
        {
            bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x,bullet.transform.eulerAngles.y,180);
        }
        else
        {
            bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x,bullet.transform.eulerAngles.y,0 );
        }
        bullet.SetActive(true);

        for(int i=0;i<quantity;i++)
        {
            bullets[i].transform.position = Golem.BulletPos.position;
            bullets[i].SetActive(true);
        }
        
    }
}
