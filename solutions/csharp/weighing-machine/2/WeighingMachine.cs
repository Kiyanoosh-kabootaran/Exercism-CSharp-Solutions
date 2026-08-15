using System;
using System.Globalization;

public class WeighingMachine
{
    public int Precision { get; }

    public WeighingMachine(int precision)
    {
        Precision = precision;
    }

    private double weight;

    public double Weight
    {
        get => weight;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Weight), "Weight cannot be negative.");

            weight = value;
        }
    }

    public double TareAdjustment{get; set;} = 5.0;

    
    public string DisplayWeight
    {
        get
        {
            double totalWeight = weight - TareAdjustment;
            string format = $"F{Precision}";
            return $"{totalWeight.ToString(format, CultureInfo.InvariantCulture)} kg";
        }
    }
}
