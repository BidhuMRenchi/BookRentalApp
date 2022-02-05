using BookRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.Repository
{
    public interface ICustomer
    {
        //GET ALL Customers -- viewModel
        Task<List<Customers>> GetAllCustomers();

        //GET CUSTOMER by id  -- viewModel
        Task<Customers> GetCustomer(int? custId);

        //ADD CUSTOMER
        Task<int> AddCustomer(Customers cust);

        //UPDATE CUSTOMER
        Task UpdateCustomer(Customers cust);

        //DELETE CUSTOMER
        Task<int> DeleteCustomer(int? custId);

    }
}
