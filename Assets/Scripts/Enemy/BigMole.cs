namespace YK
{
    public class BigMole : Enemy
    {
        public BigMole()
        {
            MaxHealth = 30;
            DisappearanceTime = 3.5f;
            ScoreValue = 30;
        }

        public BigMole (int incomingDamage) : base(incomingDamage) { }
    }
}
