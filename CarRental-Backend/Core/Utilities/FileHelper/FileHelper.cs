using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        private static string newPath(IFormFile formfile)
        {
            FileInfo fullName = new FileInfo(formfile.FileName);
            string fileExtension = fullName.Extension;

            string path = Environment.CurrentDirectory + @"\Images";
            var creatingName = Guid.NewGuid().ToString("Image") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + fileExtension;

            string result = Path.Combine(path, creatingName);
            return result;
        }
        public static IDataResult<string> Add(IFormFile formFile)
        {
            var filePath = newPath(formFile);
            if (formFile != null)
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            return new SuccessDataResult<string>(filePath);

        }
        public static IResult Delete(string filePath)
        {
            File.Delete(filePath);
            return new SuccessResult();
        }
        public static IDataResult<string> Update(IFormFile formFile, string oldPath)
        {
            var filePath = newPath(formFile);
            if (oldPath.Length > 0)
            {
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    formFile.CopyTo(fileStream);
                }
            }
            File.Delete(oldPath);
            return new SuccessDataResult<string>(filePath);
        }
    }
}
