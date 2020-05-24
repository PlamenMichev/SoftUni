namespace _01.TestAxe.Contracts
{
    public interface ITarget
    {
        bool IsDead();

        void TakeAttack(int attackPoints);

        int GiveExperience();
    }
}
