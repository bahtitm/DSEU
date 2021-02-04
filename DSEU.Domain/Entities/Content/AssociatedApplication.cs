using System.Collections.Generic;
using System.Linq;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Entities.Content
{
    /// <summary>
    /// Приложение-обработчик
    /// </summary>
    public class AssociatedApplication : DatabookEntry
    {
        private static HashSet<string> previewExtensions = new HashSet<string>(new string[]{ ".doc", ".docx", ".rtf",".dot",".dotx",".docm",".dotm", ".xls", ".xlsx",
            ".xlsm",".ods",".jpg",".jpeg",".bmp",".png",".gif",".tif",".tiff",".pptm",".pptx",".potx",".potm",".pdf",".txt"});

        /// <summary>
        /// Наименование обработчика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Расширение
        /// </summary>
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int FilesTypeId { get; set; }
        public static bool CanBeOpenWithPreview(string extension)
        {
            return previewExtensions.Any(ext => ext == extension?.ToLower());
        }
        public FilesType FilesType { get; set; }

        public bool CanConvertToPdf() => Extension switch
        {
            ".docx" => true,
            ".doc" => true,
            ".rtf" => true,
            ".dot" => true,
            ".dotx" => true,
            ".docm" => true,
            ".dotm" => true,
            ".xls" => true,
            ".xlsx" => true,
            ".xlsm" => true,
            ".pptm" => true,
            ".pptx" => true,
            ".potx" => true,
            ".potm" => true,
            _ => false,
        };
    }
}
