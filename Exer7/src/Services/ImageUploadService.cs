namespace Exer7App.Services;

public class ImageUploadService
{
  private static readonly string[] AllowedExtensions = [".jpg", ".jpeg", ".png"];
  private readonly IWebHostEnvironment _environment;

  public ImageUploadService(IWebHostEnvironment environment)
  {
    _environment = environment;
  }

  public bool IsAllowedImage(IFormFile file)
  {
    var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
    return AllowedExtensions.Contains(extension);
  }

  public (bool Success, List<string> Paths, string? ErrorMessage) SaveImages(
    IEnumerable<IFormFile> files,
    string folder)
  {
    var savedPaths = new List<string>();

    foreach (var file in files)
    {
      if (file.Length == 0)
      {
        continue;
      }

      if (!IsAllowedImage(file))
      {
        return (false, savedPaths, "Chỉ cho phép upload file jpg/png");
      }

      var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
      var fileName = $"{Guid.NewGuid():N}{extension}";
      var uploadDirectory = Path.Combine(_environment.WebRootPath, "uploads", folder);
      Directory.CreateDirectory(uploadDirectory);

      var physicalPath = Path.Combine(uploadDirectory, fileName);
      using (var stream = new FileStream(physicalPath, FileMode.Create))
      {
        file.CopyTo(stream);
      }

      savedPaths.Add($"/uploads/{folder}/{fileName}");
    }

    return (true, savedPaths, null);
  }
}
