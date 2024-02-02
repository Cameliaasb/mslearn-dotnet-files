// using System.IO;
// using System.Collections.Generic;

// var salesFiles = FindFiles("stores");

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }


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


var currentDirectory = Directory.GetCurrentDirectory();                         // mslearn ..
var storesDirectory = Path.Combine(currentDirectory, "stores");                 // mslearn../stores

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");            // chemin qui n'existe pas
Directory.CreateDirectory(salesTotalDir);                                       // Crée le chemin (dossier salesTotalDir) : une seule fois.
File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);     // Crée un fichier totals.txt vide dans e dossier salesTotalDir

var salesFiles = FindFiles(storesDirectory);                                    // recup les fichiers json du dossier (et ses sous-dossiers)

var sales_201 = File.ReadAllText($"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json"); // stores/201/sales.json
Console.WriteLine(sales_201);        // { "Total": 501.22 }  càd string avec le contenu du fichier stores/201/sales.json
