using System.Diagnostics;
using System.Reflection;

string diskSpace = "C:\\Users\\";
string Name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
string desktopName = Name.Substring(0, Name.IndexOf('\\'));
string path = "\\AppData\\Roaming\\NCALayer\\bundles\\";
string exepath = "\\AppData\\Roaming\\NCALayer\\NCALayer.exe";

string username = Name.Replace(desktopName + "\\", "");
string fullpath = diskSpace + username + path;
string filepath = Path.GetFullPath("kz.nitec.eup.eupsigner_1.0_1023ad25-d3ed-4569-a628-d61325f02dc6.jar");
//  var fileByteArray = ConvertToByteArray(filepath);
//CopyFile(filepath, fullpath + Path.GetFileName(filepath));
//CheckNcaLayerProcess();


string pathtoResource = "ModuleInstallerNetCore.kz.nitec.eup.eupsigner_1.0_1023ad25-d3ed-4569-a628-d61325f02dc6.jar";
var assembly = Assembly.GetExecutingAssembly();
using (var stream = assembly.GetManifestResourceStream(pathtoResource))
{
   var file =  UseStreamDotReadMethod(stream);
    SaveByteArrayToFileWithStaticMethod(file, fullpath);
}
 static void SaveByteArrayToFileWithStaticMethod(byte[] data, string filePath)
  => File.WriteAllBytes(filePath + "kz.nitec.eup.eupsigner_1.0_1023ad25-d3ed-4569-a628-d61325f02dc6.jar", data);
byte[] UseStreamDotReadMethod(Stream stream)
{
    byte[] bytes;
    List<byte> totalStream = new();
    byte[] buffer = new byte[32];
    int read;
    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
    {
        totalStream.AddRange(buffer.Take(read));
    }
    bytes = totalStream.ToArray();
    return bytes;
}
//void CopyFile(string file, string path)
//{
//    try
//    {
//        File.Copy(file, path, true);
//    }
//    catch (IOException iox)
//    {
//        Console.WriteLine(iox.Message);
//    }
//}
//void CheckNcaLayerProcess()
//{
//    try
//    {
//        Process[] ncaproceses = Process.GetProcessesByName("javaw");
//        foreach (var proc in ncaproceses)
//        {
//            proc.Kill();
//        }
//        Thread.Sleep(1000);
//        string username = Name.Replace(desktopName + "\\", "");
//        string NcaExe = diskSpace + username + exepath;
//        Process.Start(NcaExe);

//    }
//    catch
//    {

//    }

//}