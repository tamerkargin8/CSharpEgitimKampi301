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

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public bool HasPermission()
        {
            // Yetki kontrolü burada yapılır
            // Eğer yetki varsa true döndürülür, yoksa false döndürülür
            return true; // Placeholder return statement, replace with actual permission check
        }

        public List<Customer> TGetAll()
        {
            if (HasPermission())
            {
                return _customerDal.GetAll();
            }
            else
            {
                Console.WriteLine("Yetkiniz bulunmamaktadır.");
                return new List<Customer>();
            }
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 && entity.CustomerCity != null && entity.CustomerSurname != "" && entity.CustomerName.Length <= 30)
            {
                _customerDal.Insert(entity);
                Console.WriteLine("Müşteri eklendi");
            }
            else
            {
                Console.WriteLine("Müşteri eklenemedi, Verileri Kontrol ediniz.");
            }
        }

        public void TUpdate(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 && entity.CustomerCity != null && entity.CustomerSurname != "" && entity.CustomerName.Length <= 30)
            {
                _customerDal.Update(entity);
                Console.WriteLine("Müşteri güncellendi");
            }
            else
            {
                Console.WriteLine("Müşteri güncellenemedi, Verileri Kontrol ediniz.");
            }
        }
    }
}
