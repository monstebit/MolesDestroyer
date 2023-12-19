namespace YK
{
    public class EnemyBigMole : Enemy
    {
        public EnemyBigMole()
        {
            MaxHealth = 30;
            DisappearanceTime = 6.5f;
            ScoreValue = 30;
        }

        public EnemyBigMole (int incomingDamage) : base(incomingDamage)
        {

        }
    }
}
