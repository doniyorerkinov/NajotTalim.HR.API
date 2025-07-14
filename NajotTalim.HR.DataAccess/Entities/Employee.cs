﻿// EntityFrameWork orqali Database bilan muloqot qilishda foydalanamiz.
// Database da ham Employee degan jadval bo'ladi va shu jadvalga CRUD amallarini bajarish uchun ishlatiladi.

namespace NajotTalim.HR.DataAccess.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
        
        public string Department { get; set; }
       
        public string Email { get; set; }

        public decimal Salary { get; set; }
        public Address Address { get; set; }
        // public int AddressId { get; set; }
    }
}
