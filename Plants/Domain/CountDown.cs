namespace Plants.Domain;

public class CountDown
{
    private int _count;
    public void Down() => _count--;

    public bool IsDone => _count <= 0;

    public static CountDown From(int from)
    {
        return new CountDown() { _count = from };
    }
}