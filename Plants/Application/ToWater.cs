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
        var sdf = await wateringCan.SelectPotToWater();
        Debug.Assert(!sdf.cancel, "Todavía no hemos hecho el escenario de cancelar");
        

        var selectedPot = garden.PotWithId(sdf.potId);
        if (selectedPot.IsEmpty)
            await feedbackView.EmptyPot(sdf.potId);
        else if (selectedPot.IsWet)
            await feedbackView.WetPot(sdf.potId);
        else
            await HappyPath(selectedPot);
    }

    Task HappyPath(Pot selectedPot)
    {
        selectedPot.Water();
        return Task.WhenAll(wateringCan.ToWater(), gardenView.UpdateWith(selectedPot));
    }
}