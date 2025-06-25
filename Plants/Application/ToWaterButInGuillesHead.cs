using System.Diagnostics;

namespace Plants.Application;

public class ToWaterButAsGuilleHadImagined
{
    WateringCan wateringCan;
    GardenView gardenView;
    
    public Task Run()
    {
        wateringCan.Show();
        var selectedPot = gardenView.SelectedPot;
        Debug.Assert(selectedPot is not null);
        return Task.CompletedTask; //Many other stuff.
    }
}