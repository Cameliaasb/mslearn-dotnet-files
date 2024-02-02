using System.IO;                               // optionnel
using System.Collections.Generic;              // optionnel
using Newtonsoft.Json;

// var salesFiles = FindFiles("stores");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// // // -----------------------------------------------------------------

// Console.WriteLine(Directory.GetCurrentDirectory());
// string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
// Console.WriteLine(docPath);

// // // -----------------------------------------------------------------

// Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// // returns:
// // stores\201 on Windows
// // stores/201 on macOS

// Console.WriteLine(Path.Combine("stores","201")); // outputs: stores/201
// Console.WriteLine(Path.GetExtension("sales.json")); // outputs: .jsons

// // // -----------------------------------------------------------------

// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

// FileInfo info = new FileInfo(fileName);

// Console.WriteLine(
//   $"Full Name: {info.FullName}{Environment.NewLine}"+
//   $" Directory: {info.Directory}{Environment.NewLine}"+
//   $"Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");
//   // And many more

// // // -----------------------------------------------------------------


// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");

// var salesFiles = FindFiles(storesDirectory);

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }

// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         var extension = Path.GetExtension(file);
//         if (extension == ".json")
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }


// File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "greeting.txt"), "Hello World!");
// // // -----------------------------------------------------------------
double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;

    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);

        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        // The file name will contain the full path, so only check the end of it
        if (file.EndsWith("sales.json"))
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}





var currentDirectory = Directory.GetCurrentDirectory();                         // mslearn ..
var storesDirectory = Path.Combine(currentDirectory, "stores");                 // mslearn../stores

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");            // chemin qui n'existe pas
Directory.CreateDirectory(salesTotalDir);                                       // Crée le chemin (dossier salesTotalDir) : Ne se passe rien s'il existe déjà
File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);     // Crée un fichier totals.txt vide dans e dossier salesTotalDir. si on change le content => ecrase l'existant

var salesFiles = FindFiles(storesDirectory);                                    // recup les fichiers json du dossier (et ses sous-dossiers)


var salesJson = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");   // stores/201/sales.json => { "Total": 501.22 }  càd string avec le contenu du fichier stores/201/sales.json
var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);   // string { "Total": 501.22 } devient un objet salesData.Total = 501.22

Console.WriteLine(salesData == null ? "salesData is null" : salesData.Total);
var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");   // Rajoute 501.22 à salesTotalDir/totals.txt


record SalesData (double Total);

class SalesTotal
{
  public double Total { get; set; }
}
