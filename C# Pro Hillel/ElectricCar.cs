using System.Reflection;
using System.Text;

public class ElectricCar : Car

{
    const double ChargeConsumption = 3.25;
    const int second = 1000;
    const int chargeSpeed = 100;

    // Створіть похідний клас ElectricCar, який додає поле batteryCapacity (double) і метод Charge(double amount), який збільшує рівень заряду батареї.
    private int maxChargeCapacity = 2750;
    public Double batteryCapacity;
    public Double BatteryCapacity { get; set; }
    public int MaxChargeCapacity
    {
        get { return maxChargeCapacity; }
        set { if (value < 0) value = 0;
        else if (value > maxChargeCapacity) value = maxChargeCapacity;
        }
    } 

    public double mileageE { get; set; }



    public ElectricCar(string Brand, string Model, int Year, double Mileage , Double BatteryCapacity) 
    {
        this.batteryCapacity = BatteryCapacity;
    }

    // метод Charge(double amount) немного отклонился от задания
    public void Charge(double ChargeTime)
     {
        StringBuilder line = new StringBuilder();

        for (int i = 0; i < ChargeTime; i++)
        {
            line.Append('*');
            Console.Clear();
            
            batteryCapacity += chargeSpeed;
            Console.Write($"Батарея заряжается: {batteryCapacity} ");
            Console.WriteLine($"{batteryCapacity}Kw, {(int)(batteryCapacity /maxChargeCapacity * 100)}% {line.ToString()}");
            Thread.Sleep(second);
            i++;
            if (batteryCapacity == MaxChargeCapacity) { break; }
        }

     }
    // Перевантажте метод Drive у класі ElectricCar, щоб він також зменшував рівень заряду батареї на основі пройденої відстані.
    public override void  Drive(double distance)
    {
        batteryCapacity -= distance*ChargeConsumption;
        if (batteryCapacity < 0)
        {
            batteryCapacity = 0;
            Console.WriteLine($"Заряд батареи  уменьшился до - {batteryCapacity} вы потратили {distance * ChargeConsumption} kw/h" +
                $"вы не доехали ");
        }
        else Console.WriteLine($"Заряд батареи  уменьшился до - {batteryCapacity} вы потратили {distance * ChargeConsumption} kw/h");
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Electric car");
        Console.WriteLine($"Brand - {brand}");
        Console.WriteLine($"Model - {model}");
        Console.WriteLine($"Year -{year}");
        Console.WriteLine($"Age - {Age}");
        Console.WriteLine($"Mill age - {mileage}");
        Console.WriteLine($"Charged - {batteryCapacity}/{MaxChargeCapacity}");
        Console.WriteLine("_____________");

    }
}
