using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appUploadFiles.Models
{
    public class FileToUploadViewModel
    {
        [Required]
        [DisplayName("Mi Archivo que arriba va")]
        public HttpPostedFileBase fileUpload01 { get; set; }
        [Required]
        public HttpPostedFileBase fileUpload02 { get; set; }
        public string texto { get; set; }
    }
}