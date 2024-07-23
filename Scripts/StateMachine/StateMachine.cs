using UnityEngine;

    public abstract class StateMachine
    {
        protected IState currentState;

        public void ChangeState(IState newState)
        {
            if(currentState != null)
            {
                currentState.Exit();
            }
            currentState = newState;
            newState.Enter();
        }

        public void HandleInput()
        {
            currentState?.HandleInput(); // check xem state hiện tại đã gọi các hàm này chưa, chưa gọi thì gọi
        }

        public void Update()
        {
            currentState?.Update();
        }
        public void PhysicsUpdate()
        {
            currentState?.PhysicsUpdate();
        }
        public void OnAnimationEnterEvent()
        {
            currentState?.OnAnimationEnterEvent();
        }

        public void OnAnimationExitEvent()
        {
            currentState?.OnAnimationExitEvent();
        }

        public void OnAnimationTransitionEvent()
        {
            currentState?.OnAnimationTransitionEvent();
        }

        public void OnTriggerEnter(Collider2D collider)
        {
            currentState?.OnTriggerEnter(collider);
        }

        public void OnTriggerExit(Collider2D collider)
        {
            currentState?.OnTriggerExit(collider);
        }
    }
