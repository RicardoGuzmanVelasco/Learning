using System.Diagnostics;
using Plants.Domain;

namespace Plants.Application;

public class ToWater
{
    readonly Garden garden;
    WateringCan wateringCan;
    GardenView gardenView;
    WateringFeedback feedbackView;

    public ToWater(Garden garden, WateringCan wateringCan, GardenView gardenView, WateringFeedback feedbackView)
    {
        this.garden = garden;
        this.wateringCan = wateringCan;
        this.gardenView = gardenView;
        this.feedbackView = feedbackView;
    }

    public async Task Run()
    {
        await wateringCan.Show();

        while(true)
            await RunOnce();
    }

    async Task RunOnce()
    {
        var selectedPotId = await wateringCan.SelectPotToWater();
        
        var selectedPot = garden.PotWithId(selectedPotId);
        if (selectedPot.IsEmpty)
            await feedbackView.EmptyPot(selectedPotId);
        else if (selectedPot.IsWet)
            await feedbackView.WetPot(selectedPotId);
        else
            await HappyPath(selectedPot);
    }

    Task HappyPath(Pot selectedPot)
    {
        selectedPot.Water();
        return Task.WhenAll(wateringCan.ToWater(), gardenView.UpdateWith(selectedPot));
    }
}