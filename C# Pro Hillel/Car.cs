using static System.Runtime.InteropServices.JavaScript.JSType;

public class Car 


{        // Створіть клас Car з наступними полями: brand(string), model(string), year(int), mileage(double).

    // объявляю поля вместе со свойствами (автоматическое свойство), но понимаю что могу делать это отдельно потому что так бывает необходимо при добавлении дополнительной логики 
    public string brand { get; set; } = "No Brand";
    public string model { get; set; } = "No Model";
    public int year { get; set; }
    // Додайте властивість Mileage з приватним сеттером і публічним геттером.
    public double mileage { get;  private set; } // можно сделать это не явно просто удалив set 


    // Додайте властивість Age, яка обчислює вік автомобіля на основі поточного року.
    public int Age
    {
        get 
        {
            DateTime date = DateTime.Now;
            int currentYear = date.Year;
            if (year == 0) { return year; }
            return currentYear - this.year;
        }
        set
        {
          
        }
    }


    public Car() {/*конструктор по умолчанию*/}

    // Додайте конструктор, який ініціалізує всі поля.
    public Car( string Brand, string Model, int Year, double Mileage) 
    {
        this.brand = Brand;
        this.model = Model;
        this.year = Year;
        this.mileage = Mileage;
    }

   

    //Додайте метод Drive(double distance), який збільшує пробіг автомобіля.
    public virtual void Drive (double distance) 
        {
             mileage=+distance;
        Console.WriteLine($"Пробег авто {brand} {model} - {mileage}");
    }

    // Додайте перевантажений метод Drive, який приймає два параметри: відстань і час, та виводить середню швидкість.
   public void Drive (double distance , double time )
    {
        double middleSpeed = distance / time;

        Console.WriteLine($"Средняя скорость {middleSpeed} км/ч");
    }


  


    public virtual void ShowInfo()
    {
        Console.WriteLine("Fuel car");
        Console.WriteLine($"Brand - {brand}");
        Console.WriteLine($"Model - {model}");
        Console.WriteLine($"Year -{year}");
        Console.WriteLine($"Age - {Age}");
        Console.WriteLine($"Mill age - {mileage}");
        Console.WriteLine("_____________");

    }

    //Додайте фіналайзер, який виводить повідомлення про видалення об'єкта.

    ~Car()
    {
        Console.WriteLine("Car was destroyed by garbage-collector\n" +
                          "______________________________________\n" +
                          "Car was destroyed by garbage-collector");

    }
}
