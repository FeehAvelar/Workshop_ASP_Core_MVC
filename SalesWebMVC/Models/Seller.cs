using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Seller
    {

        #region Basic Attributes
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        //[StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between 3 and 60 char")]
        [StringLength (60, MinimumLength = 3, ErrorMessage ="{0} size should be between {2} and {1} char")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.00, 50000.00, ErrorMessage = "{0} must be from {1} to {2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Base Salary")]
        //[DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        #endregion

        # region Associations
        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();
        #endregion

        #region Constructors
        public Seller()
        {
        }

        public Seller(int id, string name, string email, double baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }
        #endregion

        //Custom Methods
        public void AddSale(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSale(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sale => sale.Date >= initial && sale.Date <= final).Sum(sale => sale.Amount);
        }
    }
}
