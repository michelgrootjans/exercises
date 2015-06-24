using System;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Exercises.Tdd
{
    [TestFixture]
    public class PersonDataAccessTests
    {
        [Test]
        public void SavePerson()
        {
            var config = new Configuration().Configure();
            using (var sessionFactory = config.BuildSessionFactory())
            {
                using (var session = sessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(new Person("Bram"));

                    session.Flush();
                    session.Clear();

                    var bram = session.QueryOver<Person>().List()[0];
                    Assert.That(bram.Name, Is.EqualTo("Bram"));

                    transaction.Rollback();
                }
            }
        }

        [Test]
        public void dispose()
        {
            var blah = new Blah();
            Console.WriteLine("2 In test");
            blah.Dispose();
        }

        [Test]
        public void dispose_bis()
        {
            using (new Blah())
            {
                Console.WriteLine("2 in test");
            }
        }
    }

    public class Blah : IDisposable
    {
        public Blah()
        {
            Console.WriteLine("1 Blah is being built");
        }

        public void Dispose()
        {
            Console.WriteLine("3 Blah is being disposed");
        }
    }
}