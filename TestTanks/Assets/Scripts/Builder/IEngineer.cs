using Scripts.Behaviour.Unit;

namespace Scripts.Builder
{
    interface IEngineer
    {
        void CreateBody();
        void CreateWeaponry();
        UnitBehaviour GetTank();

    }
}
