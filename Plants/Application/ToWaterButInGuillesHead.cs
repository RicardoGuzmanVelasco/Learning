using System.Diagnostics;
using Plants.Domain;

namespace Plants.Application;



public class ToWaterButAsGuilleHadImagined
{
    WateringCan wateringCan;
    Carrousel<Pot> carrousel;

    
    public Task Run()
    {
        wateringCan.Show();
        var selectedPot = carrousel.Current;
        Debug.Assert(selectedPot is not null);
        return Task.CompletedTask; //Many other stuff.
    }
}