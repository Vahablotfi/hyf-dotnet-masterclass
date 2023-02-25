var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



//1. String manipulation

app.MapGet("/Exercise1", (string input) => {
    char[] charArray = input.ToCharArray();
    Array.Reverse(charArray);
    return new string(charArray);
});



//2. String/Math

app.MapGet("/Exercise2", (string input) =>
{
    char[] vowels = { 'a', 'o', 'e', 'i', 'u' };

    int vowelCount = 0;

    string sentence = input.ToLower();

    for (int i = 0; i < sentence.Length ; i++)
{
    if ( vowels.Contains(sentence[i]))
    {
            vowelCount++;
        }
}
return $"{input} Contains {vowelCount} vowel";
} );

//3. Math/Array


app.MapGet("/Exercise3", () => {
    int[] arr = new[] { 271, -3, 1, 14, -100, 13, 2, 1, -8, -59,  -1852, 41, 5 };
    int sumOfNegatives = 0;
    int multiOfPositive =1;
    for (int i = 0; i < arr.Length; i++)
    { 
        if (arr[i]<= 0)
        {
            sumOfNegatives -= arr[i];
        } else{
            multiOfPositive *= arr[i];
        }
        
    }
    return $"Sum of negative numbers: {sumOfNegatives}. Multiplication of positive numbers: {multiOfPositive}";
});

//4. Classical task  Fibonacci 


app.MapGet("/Fibonacci", (int input) => {

    var fibonacciNumbers = new List<int> { 0, 1 };


if (input<=1)
    {
        return $"{input} fibonacci number is the same as {input}";
    } 
    else
    {
          do
    {
         fibonacciNumbers.Add(fibonacciNumbers[fibonacciNumbers.Count - 1] + fibonacciNumbers[fibonacciNumbers.Count - 2]);
    } while (fibonacciNumbers.Count<=input);
  
    };
      return $"{input} fibonacci number is :{fibonacciNumbers[fibonacciNumbers.Count - 1]}";

});


app.Run();
