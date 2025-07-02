// [Required] shu moduldan keladi
using System.ComponentModel.DataAnnotations;


namespace NajotTalim.HR.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        // Employee class da [Required] atributi ishlatiladi, bu modelni validatsiya qilish uchun
        // Agar FullName bo'sh bo'lsa, server 400 Bad Request qaytaradi
        [Required]
        // [StringLength(50)] atributi FullName ning maksimal uzunligini 50 belgiga cheklaydi
        [StringLength(50, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Department { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
