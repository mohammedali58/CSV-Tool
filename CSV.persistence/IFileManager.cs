using System.Collections.Generic;
using CSV.Core.Model;

namespace CSV.persistence
{
    public interface IFileManager
    {
        List<Log> Read(string filePath);
        void Write<T>(string filePath, List<T> data);
    }
}