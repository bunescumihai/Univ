
namespace AppCore.Services.State;

public class ResultsCalculator
{
    public StudentState State;

    public ResultsCalculator(StudentState state)
    {
        State = state;
    }

    public void NotifyStudent()
    {
        State.SendMessage();
    }

    public void SetState(StudentState state)
    {
        this.State = state;
    }
}