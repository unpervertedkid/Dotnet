var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory,"stores");

var salesTotalDirectory = Path.Combine(currentDirectory,"salesTotalDir");
Directory.CreateDirectory(salesTotalDirectory);

var salesFiles = FindFiles(storesDirectory);

File.WriteAllText(Path.Combine(salesTotalDirectory, "totals.txt"), String.Empty);

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