using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Insert(Customer entity)
        {
            if (ValidateCustomerForInsert(entity))
            {
                _customerDal.Insert(entity);
            }
            else
            {
                throw new ArgumentException("Müşteri bilgileri geçersiz. Lütfen tüm alanları doğru şekilde doldurun.");
            }
        }

        public void Update(Customer entity)
        {
            if (ValidateCustomerForUpdate(entity))
            {
                _customerDal.Update(entity);
            }
            else
            {
                throw new ArgumentException("Müşteri güncelleme bilgileri geçersiz. Lütfen tüm alanları doğru şekilde doldurun.");
            }
        }

        public void Delete(Customer entity)
        {
            if (entity?.CustomerId > 0)
            {
                _customerDal.Delete(entity);
            }
            else
            {
                throw new ArgumentException("Silinecek müşteri bulunamadı.");
            }
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            if (id > 0)
            {
                return _customerDal.GetById(id);
            }
            throw new ArgumentException("Geçersiz müşteri ID'si.");
        }

        private bool ValidateCustomerForInsert(Customer entity)
        {
            if (entity == null) return false;

            return !string.IsNullOrWhiteSpace(entity.CustomerName) &&
                   entity.CustomerName.Length >= 3 &&
                   entity.CustomerName.Length <= 30 &&
                   !string.IsNullOrWhiteSpace(entity.CustomerSurname) &&
                   entity.CustomerSurname.Length >= 2 &&
                   entity.CustomerSurname.Length <= 30 &&
                   !string.IsNullOrWhiteSpace(entity.CustomerCity) &&
                   entity.CustomerCity.Length >= 2 &&
                   entity.CustomerCity.Length <= 50;
        }

        private bool ValidateCustomerForUpdate(Customer entity)
        {
            if (entity == null || entity.CustomerId <= 0) return false;

            return !string.IsNullOrWhiteSpace(entity.CustomerName) &&
                   entity.CustomerName.Length >= 3 &&
                   entity.CustomerName.Length <= 30 &&
                   !string.IsNullOrWhiteSpace(entity.CustomerSurname) &&
                   entity.CustomerSurname.Length >= 2 &&
                   entity.CustomerSurname.Length <= 30 &&
                   !string.IsNullOrWhiteSpace(entity.CustomerCity) &&
                   entity.CustomerCity.Length >= 2 &&
                   entity.CustomerCity.Length <= 50;
        }
    }
}
