using Plants.Domain;

namespace Plants.Application;

public interface GardenView
{
    Task UpdateWith(Pot model);
    Pot SelectedPot { get; }
}