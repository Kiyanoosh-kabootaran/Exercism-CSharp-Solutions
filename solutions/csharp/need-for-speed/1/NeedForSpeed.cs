class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class
    public int Speed {get; private set;}
    public int BatteryDrain {get; private set;}
    
    int distanceDriven = 0;
    int battery = 100;

    public RemoteControlCar(int speed,int batteryDrain)
    {
        this.Speed = speed;
        this.BatteryDrain = batteryDrain;
    }
    

    public bool BatteryDrained()
    {
        return battery < BatteryDrain;
    }

    public int DistanceDriven()
    {   
        return distanceDriven;
    }

    public void Drive()
    {
        if(battery >= BatteryDrain)
        {
            distanceDriven += Speed;
            battery -= BatteryDrain;
        }
        
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50,4);
    }
}

class RaceTrack
{
    private int distance;
    
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int numOfDrives = (int)Math.Ceiling((double)distance / car.Speed); 
        int batteryNeeded = numOfDrives * car.BatteryDrain;

        return batteryNeeded <= 100 ;
    }
}
