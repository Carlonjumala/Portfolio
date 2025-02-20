using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class Certification
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public DateTime DateObtained { get; set; }
        public string CertificateUrl { get; set; } = string.Empty;        // No need to specify nvarchar(max) here
    }
}
