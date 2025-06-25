namespace Plants.Application;

public interface WateringCan
{
    Task Show();
    Task<PotSelection> SelectPotToWater();
    Task ToWater();

    readonly struct PotSelection
    {
        public readonly string potId;
        public readonly bool cancel;
    }

    Task Hide();
}