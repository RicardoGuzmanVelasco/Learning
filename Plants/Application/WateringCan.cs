namespace Plants.Application;

public interface WateringCan
{
    Task Show();
    Task<string> SelectPotToWater();
    Task ToWater();
}