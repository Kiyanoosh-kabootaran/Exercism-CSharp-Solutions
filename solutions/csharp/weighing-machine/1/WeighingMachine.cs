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

    private double tareAdjustment = 5.0;

    public double TareAdjustment
    {
        get => tareAdjustment;
        set{tareAdjustment = value;}
    }

    
    public string DisplayWeight
    {
        get
        {
            double totalWeight = weight - tareAdjustment;
            string format = $"F{Precision}";
            return $"{totalWeight.ToString(format, CultureInfo.InvariantCulture)} kg";
        }
    }
}
