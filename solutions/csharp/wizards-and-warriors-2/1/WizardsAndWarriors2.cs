static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        switch(travelMethod)
        {
            case TravelMethod.Walking: 
                return "You're traveling to your destination by walking.";
            case TravelMethod.Horseback:
                return "You're traveling to your destination on horseback.";
            default:
                return "Unknown travel method";
        }
             
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
       string characterDesc = Describe(character);
       string destinationDesc = Describe(destination);
       string travelDesc = Describe(travelMethod);

       return $"{characterDesc} {travelDesc} {destinationDesc}";
    }

    public static string Describe(Character character, Destination destination)
    {
       string characterDesc = Describe(character);
       string destinationDesc = Describe(destination);
        string travelDesc = Describe(TravelMethod.Walking);

       return $"{characterDesc} {travelDesc} {destinationDesc}";
    }
}

class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}
