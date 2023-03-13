var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");



     var celsiusTemperature = new Temperature(17.00m);

        string MakeSound (IAnimal animal){
          return $"{animal.Name} says {animal.Sound}";
        }  

        var Cat = new Animal("Cat","meow meow");
        var Dog = new Animal("Dog","woof woof");
        var Cow = new Animal("Cow","maa maa");
        var DogSound = MakeSound(Dog);

app.Run();



 

       




// Temperature Class
public class Temperature
{
    private decimal _temperatureAlert = -273.15m;
    private decimal _degreesCelsius;
    
    public decimal DegreesCelsius
    {
    get => _degreesCelsius;
        private set
    {
        if (decimal.Compare(_degreesCelsius, _temperatureAlert) < 0)
        {
            throw new Exception("this is so cold you should be careful");
        }
        _degreesCelsius = value;
    }
    }


    public decimal FahrenheitDegrees 
        {
        get =>  DegreesCelsius + 32;
        }

    public Temperature(decimal degrees)
    {
        DegreesCelsius = degrees;
    }
}



 //class  ExchangeRate 

public class ExchangeRate
{
    public string FromCurrency{ get; set; }
    public string ToCurrency{ get; set; }
    public decimal Rate{ get; set; }
    public ExchangeRate(string fromCurrency,string toCurrency, decimal rate)
    {
        if (rate <= 0)
        {
            throw new Exception("input rate is not valid, must be above 0");
        }
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        Rate = rate;
    }

    public decimal Calculate(decimal amount)
    {
        if (amount <=0)
        {
            throw new Exception("we don't play around, input a valid amount");
        }
        return amount * Rate;
    } 
}


 //interface IAnimal 

interface IAnimal{
    string Name { get; set; }
    string Sound{ get; set; }
}

public class Animal : IAnimal{
    public string Name { get; set; } 
    public string Sound { get; set; } 
    public Animal(string name, string sound)
    {
        Name = name ;
        Sound = sound  ;
    }

}

 


//Account Class

public class Account{
    
    public double Balance { get; private set; }

    public double Deposit(double depositInput){
        return Balance += depositInput;
    }

    public double Withdraw (double withdraw){
        if (Balance - withdraw < 0 ){
            throw new Exception("you can not take more than your balance");
        } else
        {
            return Balance -= withdraw;
        }

      
    }
      public Account(double initialAmount)
    {
        if(initialAmount < 100 ){
            throw new Exception("The minimum requirement to open an account is 100");
        }
        Balance = initialAmount;
    }
}


