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

        bool again;
        do again = await RunOnce();
        while (again);
    }

    async Task<bool> RunOnce()
    {
        var response = await wateringCan.SelectPotToWater();
        if (response.cancel)
            return await CancelPath();
        
        var selectedPot = garden.PotWithId(response.potId);
        if (selectedPot.IsEmpty)
            await feedbackView.EmptyPot(response.potId);
        else if (selectedPot.IsWet)
            await feedbackView.WetPot(response.potId);
        else
            await HappyPath(selectedPot);

        return true;
    }

    async Task<bool> CancelPath()
    {
        await wateringCan.Hide();
        return false;
    }

    Task HappyPath(Pot selectedPot)
    {
        selectedPot.Water();
        return Task.WhenAll(wateringCan.ToWater(), gardenView.UpdateWith(selectedPot));
    }
}