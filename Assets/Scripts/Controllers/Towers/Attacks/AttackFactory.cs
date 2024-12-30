using DTOs;
using Enums;

namespace Controllers.Towers.Attacks
{
    public static class AttackFactory
    {
        public static AttackStrategy Create(TowerAttackDTO towerAttackDTO)
        {
            return towerAttackDTO.AttackPatternType switch
            {
                AttackPatternType.Plus  => new PlusAttack(towerAttackDTO),
                AttackPatternType.Cone  => new ConeAttack(towerAttackDTO),
                _ => new DefaultAttack(towerAttackDTO)
            };
        }
    }
}