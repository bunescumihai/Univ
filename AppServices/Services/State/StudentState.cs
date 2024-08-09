namespace AppCore.Services.State;

public abstract class StudentState
{
    protected ResultsCalculator _context;

    public StudentState(ResultsCalculator context)
    {
        _context = context;
    }

    public abstract void SendMessage();

    public abstract void ChangeState();
}