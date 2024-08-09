namespace AppCore.Services.State;

public class ContractState : StudentState
{
    public ContractState(ResultsCalculator context) : base(context)
    {
    }

    public override void SendMessage()
    {
        Console.WriteLine("Achitati Contractul !!!");
    }

    public override void ChangeState()
    {
        _context.SetState(new BugetState(_context));
    }
}