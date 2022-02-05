using BookRentalApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRentalApp.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly BookRentalDBContext _context;

        public CustomerRepository(BookRentalDBContext context)
        {
            _context = context;
        }

        //ADD CUSTOMER
        #region ADD CUSTOMER
        public async Task<int> AddCustomer(Customers cust)
        {
            if (_context != null)
            {
                await _context.Customers.AddAsync(cust);
                await _context.SaveChangesAsync();
                return cust.CId;
            }
            return 0;
        }
        #endregion

        //DELETE CUSTOMER
        #region DELETE CUSTOMER
        public async Task<int> DeleteCustomer(int? custId)
        {
            int result = 0;
            if (_context != null)
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.CId == custId);

                //check condition
                if (customer != null)
                {
                    _context.Customers.Remove(customer);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
        #endregion

        //GET ALL CUSTOMERS
        #region GET ALL CUSTOMERS
        public async Task<List<Customers>> GetAllCustomers()
        {
            if (_context != null)
            {
                return await _context.Customers.ToListAsync();
            }
            return null;
        }
        #endregion

        //GET CUSTOMRE BY ID 
        #region GET CUSTOMRE BY ID
        public async Task<Customers> GetCustomer(int? custId)
        {
            if (_context != null)
            {
                var cust = await _context.Customers.FindAsync(custId);// concentrating on primary key
                return cust;
            }
            return null;
        }
        #endregion

        //UPDATE CUSTOMER
        #region UPDATE CUSTOMER
        public async Task UpdateCustomer(Customers cust)
        {
            if (_context != null)
            {
                _context.Entry(cust).State = EntityState.Modified;
                _context.Customers.Update(cust);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }
        #endregion

    }
}
