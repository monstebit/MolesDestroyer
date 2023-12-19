namespace YK
{
    public class EnemySmallMole : Enemy
    {
        public EnemySmallMole()
        {
            MaxHealth = 10;
            DisappearanceTime = 4.5f;
            ScoreValue = 10;
        }

        public EnemySmallMole(int incomingDamage) : base(incomingDamage) 
        {
            
        }
    }
}