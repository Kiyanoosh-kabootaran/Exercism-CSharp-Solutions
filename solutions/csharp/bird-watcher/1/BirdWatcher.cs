class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        int lastIndex = birdsPerDay.Length - 1;
        
        return birdsPerDay[lastIndex];
    }

    public void IncrementTodaysCount()
    {
       birdsPerDay[^1]++ ;
    }

    public bool HasDayWithoutBirds()
    {
       int target = 0;
        
        bool exists = Array.Exists(birdsPerDay, element => element == target);
        
        return exists;        
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int sumOfBirds = 0;
        for(int i = 0 ; i < numberOfDays ; i++)
        {
            sumOfBirds += birdsPerDay[i];
        }

        return sumOfBirds;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach(int item in birdsPerDay)
        {
            if (item >= 5)
            {
                busyDays++;
            }
        }
        return busyDays;
    }
}
