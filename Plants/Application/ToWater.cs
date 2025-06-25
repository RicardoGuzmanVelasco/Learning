using Plants.Domain;

namespace Plants.Application;

public class ToWater
{
    readonly Garden garden;
    WateringCan wateringCan;
    GardenView gardenView;

    public ToWater(Garden garden, WateringCan wateringCan, GardenView gardenView)
    {
        this.garden = garden;
        this.wateringCan = wateringCan;
        this.gardenView = gardenView;
    }

    public async Task Run()
    {
        await wateringCan.Show();
        var selectedPotId = await wateringCan.SelectPotToWater();

        var selectedPot = garden.PotWithId(selectedPotId);
        selectedPot.Water();

        await Watering(selectedPot);
    }

    Task Watering(Pot selectedPot)
    {
        return Task.WhenAll(wateringCan.ToWater(), gardenView.UpdateWith(selectedPot));
    }
}