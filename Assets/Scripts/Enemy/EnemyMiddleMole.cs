namespace YK
{
    public class EnemyMiddleMole : Enemy
    {
        public EnemyMiddleMole()
        {
            MaxHealth = 20;
            DisappearanceTime = 3.5f;
            ScoreValue = 20;
        }

        public EnemyMiddleMole(int incomingDamage) : base(incomingDamage)
        {

        }
    }
}
