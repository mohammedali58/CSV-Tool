using System.IO;
using System.Reflection;
using CSV.persistence;
using CSV.Core;
using CSV.application;
using Microsoft.AspNetCore.Mvc;
using CSV.Core.Model;

namespace CSV_Tool.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{


    private ILogResolver _logResolver;
    private IFileManager _fileManager;
    public HomeController(ILogResolver logResolver, IFileManager fileManager)
    {
        _logResolver = logResolver;
        _fileManager = fileManager;
    }

    [HttpPost(Name = "uploadfile")]
    public string  PostFile(IFormFile file)
    {

        var fileextension = Path.GetExtension(file.FileName);
        var filename = file.FileName;
        var filepath = filename;
        using (FileStream fs = System.IO.File.Create(filepath))
        {
            file.CopyTo(fs);
        }
        if (fileextension == ".csv")
        {
            var logs = _fileManager.Read(filepath);
            (List<Productavg>, List<PopularBrand>) res = _logResolver.Solve(logs);
            _fileManager.Write<Productavg>("0_" + filename, res.Item1);
            _fileManager.Write<PopularBrand>("1_" + filename, res.Item2);
            return " files created successfully";
        }
        else
            return "please load the right format";
    }
}

