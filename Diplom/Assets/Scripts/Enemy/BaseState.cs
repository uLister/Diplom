// BaseState.cs
namespace Enemy
{
    public abstract class BaseState
    {
        public virtual void Enter() {}
        public virtual void LogicUpdate() {}
        public virtual void Exit() {}
    }
}