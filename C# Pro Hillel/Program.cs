using System.Reflection;
using static Car;
using static System.Net.Mime.MediaTypeNames;

public enum ProgramFunc
{
    ShowInfo = 1,
    CreateCar = 2,
    Drive = 3,
    OverDrive = 4,
    AgeCar = 5,
    Charge = 6,
    ElectricDrive = 7

}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в автосалон");

        String Brand = "No brand", Model = "No Model" ;
        int Year = 0;
        Double Mileage = 0;
        Car car = new Car(Brand, Model, Year, Mileage );
        ElectricCar electricCar = new ElectricCar(Brand, Model, Year, Mileage, BatteryCapacity:0);

        

        while (true)
        {

            Console.WriteLine($"Выберите функцию  которую хотите использовать :\n" +
            $"1# Показать информацию\n" +
            $"2# Обновить данные автомобилей\n" +
            $"3# Drive(double distance) - добавить  пробег авто \n" +
            $"4# Drive (Distance and Time) - средняя скорость авто \n" +
            $"==============================================================================\n" +
            $"Electric Car function\n" +
            $"5# Charge (double ChargeTime) - позволяет зарядить электро-автомобиль  \n" +
            $"6# Drive(double distance) - тратим электричество ");

            Console.Write("Поле ввода:"); var ProgramReq = (ProgramFunc)Convert.ToInt32(Console.ReadLine());
            
            switch (ProgramReq)

            {
                case ProgramFunc.ShowInfo:
                    Console.Clear();
                    
                    car.ShowInfo();
                    electricCar.ShowInfo();
                    Console.WriteLine("\n");
                break;
                case ProgramFunc.CreateCar:
                    DateTime date = DateTime.Now;
                    int currentYear = date.Year;
                    Console.Clear();
                    Console.WriteLine("Какой автомобиль хотите добавить ? 1 - \"Топливный\" ; 2 - \"Электрический\"");
                    Console.Write("Поле ввода:"); int Ch = Convert.ToInt32( Console.ReadLine());
                    if (Ch == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите параметры вашего авто:");
                        Console.Write("Введите бренд: ");
                        car.brand = Console.ReadLine() ?? "No Brand";
                        Console.Write("Введите Модель: ");
                        car.model = Console.ReadLine() ?? "No Model";
                        Console.Write("Введите год выпуска - ");

                        int year = Convert.ToInt32(Console.ReadLine());
                        if (year > date.Year)
                        { Console.WriteLine("вы из будущего"); }
                        else 
                            car.year = year;
                        Console.WriteLine("\n");


                        car.ShowInfo();
                    }
                    else if (Ch == 2){
                        Console.Clear();
                        Console.WriteLine("Введите параметры вашего авто:");
                        Console.Write("Введите бренд: ");
                        electricCar.brand = Console.ReadLine() ?? "No Brand";
                        Console.Write("Введите Модель: ");
                        electricCar.model = Console.ReadLine() ?? "No Model";
                        Console.Write("Введите год выпуска - ");

                        int year = Convert.ToInt32(Console.ReadLine());
                        if (year > date.Year)
                        { Console.WriteLine("вы из будущего"); }
                        else
                            electricCar.year = year;

                        Console.Write($"Введите заряд батареи до {electricCar.MaxChargeCapacity} - ");
                        electricCar.batteryCapacity = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\n");
                        electricCar.ShowInfo();
                    }
                    else Console.Clear(); break;



                case ProgramFunc.Drive:
                    double distance;
                    Console.WriteLine("Какой автомобиль хотите выбрать ? 1 - \"Топливный\" ; 2 - \"Электрический\"");
                    Console.Write("Поле ввода:");  Ch = Convert.ToInt32(Console.ReadLine());
                    if (Ch == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Какой пробег топливного авто?");
                        distance = Convert.ToDouble(Console.ReadLine());
                        car.Drive(distance);
                    }
                    else if (Ch == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Какой пробег электро-авто?");
                        distance = Convert.ToDouble(Console.ReadLine());
                        car.Drive(distance);
                    }
                    break;


                case ProgramFunc.OverDrive:
                    Console.Clear();
                    Console.WriteLine("Узнаём среднюю скорость!");
                    Console.Write("Введите дистанцию в км: ");
                    distance = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Введите длительность поездки в часах: ");
                    double time = Convert.ToDouble(Console.ReadLine());
                    car.Drive(distance, time);
                    Console.WriteLine();
                    break;


                case ProgramFunc.AgeCar:
                    Console.Clear();
                    distance = Convert.ToDouble(Console.ReadLine());
                    time = Convert.ToDouble(Console.ReadLine());
                    car.Drive(distance, time);
                break;


                case ProgramFunc.Charge:
                    Console.Clear();
                    Console.WriteLine("Как долго будем на розетке ?");
                    time = Convert.ToDouble(Console.ReadLine());
                    electricCar.Charge(time);
                break;

                case ProgramFunc.ElectricDrive:
                    Console.Clear();
                    Console.Write("Введите расстояние:");
                    distance = Convert.ToDouble(Console.ReadLine());
                    
                    electricCar.Drive(distance);
                    Console.WriteLine();
                    break;
            }
        }
    }
}