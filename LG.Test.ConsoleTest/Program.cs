using LG.Test.Application;
using LG.Test.Domain.Entities;
using LG.Test.Domain.Interfaces.Applications;
using LG.Test.Domain.Interfaces.Infra;
using LG.Test.Domain.Interfaces.Repositories;
using LG.Test.Domain.Interfaces.Services;
using LG.Test.Infra;
using LG.Test.Infra.Data;
using LG.Test.Infra.Repositories;
using LG.Test.Services;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LG.Test.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criação do esquema do Banco
            NHibernateHelper.GenerateSchema();
            Console.WriteLine("Schema generated");


            /*
            //Exemplo inserção manual
            ISessionFactory sessionFactory = NHibernateHelper.GetSessionFactory();
            ISession session = sessionFactory.OpenSession();

            User user1 = new User()
            {
                Name = "Luiz",
                Password = "123456"
            };

            ITransaction transaction = session.BeginTransaction();
            session.Save(user1);
            transaction.Commit();

            session.Close();
            */

            /*
            // Teste com unit of work
            IUnitOfWork uow = new UnitOfWork();
            IUserRepository userRep = new UserRepository(uow);
            uow.BeginTransaction();
            User user2 = new User()
            {
                Name = "Maria2",
                Password = "123456"
            };

            userRep.Add(user2);
            uow.Commit();
            */

            /*
            IUnitOfWork uow = new UnitOfWork();
            ICategoryRepository carRep = new CategoryRepository(uow);
            uow.BeginTransaction();
            Category cat = new Category()
            {
                Name = "Roupas"                
            };

            carRep.Add(cat);
            uow.Commit();
            */

            /*
            IUnitOfWork uow = new UnitOfWork();
            ICategoryRepository catRep = new CategoryRepository(uow);
            Category cat = catRep.Get(_ => _.Id == 1);
            IProductRepository prodRep = new ProductRepository(uow);
            uow.BeginTransaction();
            Product prod = new Product()
            {
                Name = "Camisa",
                Description = "Camisa de manga comprida",
                Picture = "http://fotodecamiseta.com.br/camisa.jpg",
                Price = 50,
                Category = cat
            };

            prodRep.Add(prod);
            uow.Commit();
            */

            /*
            //utilizando service
            IUnitOfWork uow = new UnitOfWork();
            ICategoryService catServ = new CategoryService(uow);
            IList<Category> cats = catServ.GetAll().ToList();

            foreach (var cat in cats)
            {
                Console.WriteLine(cat.Name);
            }
            */

            
            /*
            //Utilizando camada application            
            IUnitOfWorkService uowServ = new UnitOfWorkService();
            ICategoryApplication catApp = new CategoryApplication(uowServ);

            Category cat1 = new Category()
            {
                Name = "Informática"
            };

            //catApp.Add(cat1);

            IList<Category> cats = catApp.GetAll().ToList();

            foreach (var cat in cats)
            {
                IProductApplication prodApp = new ProductApplication(uowServ);
                Product prod = new Product()
                {
                    Name = "Mouse",
                    Description = "Mouse óptico",
                    Picture = "mouse.png",
                    Price = 25,
                    Category = cat
                };

                prodApp.Add(prod);
                   
                Console.WriteLine(cat.Name);
            }
            */
            

            Console.ReadKey();
        }
    }
}
