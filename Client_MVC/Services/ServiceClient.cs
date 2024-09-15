using Client_MVC.Models;

namespace Client_MVC.Services
{
    public static class ServiceClient
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer {Id = 1, FirstName = "Sasha", LastName = "Mushenko", Email = "mcasha888@gmail.com"},
            new Customer {Id = 2, FirstName = "Anna", LastName = "Kulbachna", Email = "annakul@gmail.com"},
            new Customer {Id = 3, FirstName = "Ivan", LastName = "Bondarenko", Email = "bondarenkoIvan@gmail.com"},
            new Customer {Id = 4, FirstName = "Tanya", LastName = "Tivonenko", Email = "tanya1997@gmail.com"},
            new Customer {Id = 5, FirstName = "Sergay", LastName = "Denysuk", Email = "denysuk1992@gmail.com"}
        };
    }
}
