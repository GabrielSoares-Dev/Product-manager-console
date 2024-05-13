namespace Products.services
{
    public class FileService
    {
        public string read(string folderName,string fileName)
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectDirectory, folderName, fileName);
            return File.ReadAllText(filePath);
        }
    }
}
