var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Exercise1 Calculator

app.MapGet("/calculator", (string order, string num1, string num2) =>

{
    var outPut = 0;

    var numberOne = int.TryParse(num1, out var numberOneParsed);
    var numberTwo = int.TryParse(num2, out var numberTwoParsed);

    if (!numberTwo || !numberOne)
    {
        return Results.Ok(new String("One of the number is not validated"));
    }

    switch (order)
    {
        case "add":
            outPut = numberOneParsed + numberTwoParsed;
            break;
        case "subtract":
            outPut = numberOneParsed - numberTwoParsed;
            break;
        case "multiplication":
            outPut = numberOneParsed * numberTwoParsed;
            break;
        default:
           return  Results.Ok(new String($"requested order is not supported"));


    };

    
    return Results.Ok(new String($"Answer is {outPut}"));

});


//Exercise2  count capital letters or assumption of numbers


app.MapGet("/detector", (string input) => {

    int result;

    var parsedInput = int.TryParse(input, out var inputAsNumber);


     if (!parsedInput)
     {
         result=CountCapitalLetters(input);
     }
      else
     {  
         result = AddNumbers(input); 
     }

    return $"your answer is {result}";

});



int AddNumbers (string input) 
{

    int sumOfAll = 0;
    foreach (var item in input )
    {
    
        int numberedChar = int.Parse(item.ToString());
        sumOfAll += numberedChar ;
    }
  
    return sumOfAll;
}

int CountCapitalLetters(string input ){

    int sumOfCapitalChars = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if (char.IsLetter(input[i])&& char.IsUpper(input[i]))
        {
            sumOfCapitalChars++;
        }
    }
    return sumOfCapitalChars;
}


//Exercise3 Sort Characters

app.MapGet("/alphabetical", (string input) => {

    var separatedChars = new List<char>();

    for (int i = 0; i < input.Length; i++)
    { 
        if (char.IsLetter(input[i]))
        {
            separatedChars.Add(input[i]);
        }
        
    }

     separatedChars.Sort();
    return separatedChars;
}); 

//Exercise4 Word Frequency Count

app.MapGet("/wordCounter", (string input) =>{
    
    var separatedInput = input.Split(" ");
    var keyValues = new Dictionary<string, int>();
    foreach (var item in separatedInput)
    {
        string word = item.ToLower();
        
        if (!keyValues.ContainsKey(word))
        {
            keyValues[word] = 1;
        } else
        {
             keyValues[word]++;
        }
    }
    return keyValues.ToList();
} );


app.Run();
