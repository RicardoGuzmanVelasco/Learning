using System.Diagnostics;
using Plants.Domain;

namespace Plants.Application;



public class ToWaterButAsGuilleHadImagined
{
    WateringCan wateringCan;
    SelectedPot garden;
    
    public Task Run()
    {
        wateringCan.Show();
        var selectedPot = garden.Current;
        Debug.Assert(selectedPot is not null);
        return Task.CompletedTask; //Many other stuff.
    }
}