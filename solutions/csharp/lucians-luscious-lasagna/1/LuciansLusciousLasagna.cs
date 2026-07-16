class Lasagna
{
    public int ExpectedMinutesInOven()
    {
        int expectedMinutesInOven = 40;

        return expectedMinutesInOven;
    }

    public int RemainingMinutesInOven(int actualMinutesInOven)
    {
        int remainingMinutesInOven = ExpectedMinutesInOven() - actualMinutesInOven;
        
        return remainingMinutesInOven;
    }

    public int PreparationTimeInMinutes(int layer)
    {
        return layer * 2;
    }

    public int ElapsedTimeInMinutes(int layerAdded , int actualMinutesInOven)
    {
        int preparationTimeInMinutes = PreparationTimeInMinutes(layerAdded);
        int totalTime = preparationTimeInMinutes + actualMinutesInOven ;

        return totalTime;
        
    }
}
