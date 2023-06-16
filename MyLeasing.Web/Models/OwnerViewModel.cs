using Microsoft.AspNetCore.Http;
using MyLeasing.Web.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Models
{
    public class OwnerViewModel : Owners
    {
        [Display(Name = "ImageFile")]
        public IFormFile ImageFile { get; set; }
    }
}
