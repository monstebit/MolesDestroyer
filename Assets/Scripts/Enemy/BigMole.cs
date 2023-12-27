namespace YK
{
    public class BigMole : Enemy
    {
        public BigMole()
        {
            MaxHealth = 30;
            DisappearanceTime = 5.5f;
            ScoreValue = 30;
        }

        public BigMole (int incomingDamage) : base(incomingDamage) { }
    }
}
