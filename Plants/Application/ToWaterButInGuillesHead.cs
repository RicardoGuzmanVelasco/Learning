using System.Diagnostics;
using Plants.Domain;

namespace Plants.Application;



public class ToWaterButAsGuilleHadImagined
{
    WateringCan wateringCan;
    Garden garden;

    
    public Task Run()
    {
        wateringCan.Show();
        var selectedPot = garden.SelectedPot;
        Debug.Assert(selectedPot is not null);
        return Task.CompletedTask; //Many other stuff.
    }
}