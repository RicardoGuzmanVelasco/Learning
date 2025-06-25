namespace Plants.Application;

public interface WateringFeedback
{
    Task EmptyPot(string potId);
    Task WetPot(string potId);
}