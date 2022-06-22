namespace Scripts.Behaviour.Unit
{
    class PlayerBaseTankBehaviour : UnitBehaviour
    {
        #region Fields


        #endregion


        #region Properties


        #endregion


        #region UnityMethods

        protected override void Awake()
        {
            base.Awake();
            _unitMovement = new PlayerBaseTankMovement(_unitData,transform);
        }

        #endregion


        #region Methods

        protected override void OnDeath()
        {
            base.OnDeath();

        }
        protected override void Revive()
        {
            base.Revive();

        }

        #endregion


        #region IDamageable

        public override void ReciveDamage(float damage)
        {
            base.ReciveDamage(damage);
        }

        #endregion
    }
}
