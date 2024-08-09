namespace AppCore.Services.State;

public class BugetState : StudentState
{
    public BugetState(ResultsCalculator context) : base(context)
    {
    }

    public override void SendMessage()
    {
        Console.WriteLine("Vina la perechi");
    }

    public override void ChangeState()
    {
        _context.SetState(new ContractState(_context));
    }
}