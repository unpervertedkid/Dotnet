using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory,"stores");

var salesTotalDirectory = Path.Combine(currentDirectory,"salesTotalDir");
Directory.CreateDirectory(salesTotalDirectory);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.WriteAllText(Path.Combine(salesTotalDirectory, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName){
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*",SearchOption.AllDirectories);

    foreach(var file in foundFiles){
        var extension = Path.GetExtension(file);
        if(extension == ".json"){
            salesFiles.Add(file);
        }
    }
    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles){
    double salesTotal = 0;

    foreach(var file in salesFiles){
        String salesJson = File.ReadAllText(file);

        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        salesTotal += data?.Total ?? 0;
    }
    return salesTotal;
}

record SalesData (double Total);