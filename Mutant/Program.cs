// See https://aka.ms/new-console-template for more information
using Mutant;

using System.Text.Json;

Console.WriteLine("Ingrese la información a validar");

try
{
    var data = Console.ReadLine();
    string[] sequences = data.Split(',');
    bool isMutant = Mutant.Mutant.IsMutant(sequences);
    Console.WriteLine($"Se ha verificado el ADN y queda como resultado que la clasificación para mutantes es: {isMutant}");
}
catch (ValidationException ex)
{
    Console.Error.WriteLine(ex.Message);
}
catch (Exception ex)
{

    throw;
}
