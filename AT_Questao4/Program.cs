static class Program
{
    static void Main(string[] args)
    {
        var assinaturas = new[] {"Assinatura1", "Assinatura2" , "Assinatura3" , "Assinatura4" , "Assinatura5", "Assinatura5", "Assinatura6"};

        Console.WriteLine($"Recursivamente: {CountValuesEqualTo("Assinatura5", assinaturas)}");
        Console.WriteLine($"Iterativamente: {CountStringValuesEqualsToValueInArray("Assinatura5", assinaturas)}");

        Console.ReadLine();
    }

    public static int CountValuesEqualTo(string value, string[] array, int indexCounter = 0, int counter = 0)
    {
        if (indexCounter >= array.Length)
        {
            return counter;
        }

        if (array[indexCounter] == value)
        {
            counter++;
        }
        return CountValuesEqualTo(value, array, indexCounter + 1, counter);
    }

    public static int CountStringValuesEqualsToValueInArray(string value, string[] array)
    {
        int counter = 0;
        foreach (var item in array)
        {
            if (item == value)
            {
                counter++;
            }
        }
        return counter;
    }
}