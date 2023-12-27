namespace YK
{
    public class MiddleMole : Enemy
    {
        public MiddleMole()
        {
            MaxHealth = 20;
            DisappearanceTime = 4.5f;
            ScoreValue = 20;
        }

        public MiddleMole(int incomingDamage) : base(incomingDamage) { }
    }
}
