namespace YK
{
    public class SmallMole : Enemy
    {
        public SmallMole()
        {
            MaxHealth = 10;
            DisappearanceTime = 1.5f;
            ScoreValue = 10;
        }

        public SmallMole(int incomingDamage) : base(incomingDamage) { }
    }
}