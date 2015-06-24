namespace Exercises.Tdd
{
    public class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        protected Person() { } // speciaal voor NHibernate

        public Person(string name)
        {
            this.name = name;
        }
    }
}