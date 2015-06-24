using NUnit.Framework;

namespace Exercises.Tdd
{
    [TestFixture]
    public class PizzaTests
    {
        [Test]
        public void Plain_Label()
        {
            IPizza pizza = new PlainPizza();
            Assert.That(pizza.GetLabel(), Is.EqualTo("Plain pizza"));
            Assert.That(pizza.GetPrice(), Is.EqualTo(5));
        }

        [Test]
        public void PizzaWithCheese()
        {
            IPizza pizza = new PlainPizza();
            pizza = new CheeseCondiment(pizza);
            Assert.That(pizza.GetLabel(), Is.EqualTo("Plain pizza with cheese"));
            Assert.That(pizza.GetPrice(), Is.EqualTo(6));
        }

        [Test]
        public void PizzaWithTomato()
        {
            IPizza pizza = new PlainPizza();
            pizza = new TomatoCondiment(pizza);
            Assert.That(pizza.GetLabel(), Is.EqualTo("Plain pizza with tomato"));
            Assert.That(pizza.GetPrice(), Is.EqualTo(7));
        }

        [Test]
        public void PizzaMargarita()
        {
            IPizza pizza = new PlainPizza();
            pizza = new CheeseCondiment(pizza);
            pizza = new TomatoCondiment(pizza);
            Assert.That(pizza.GetLabel(), Is.EqualTo("Plain pizza with cheese with tomato"));
            Assert.That(pizza.GetPrice(), Is.EqualTo(8));
        }

        [Test]
        public void PizzaMargarita_WithExtraCheese()
        {
            IPizza pizza = new PlainPizza();
            pizza = new CheeseCondiment(pizza);
            pizza = new CheeseCondiment(pizza);
            pizza = new TomatoCondiment(pizza);
            Assert.That(pizza.GetLabel(), Is.EqualTo("Plain pizza with cheese with cheese with tomato"));
            Assert.That(pizza.GetPrice(), Is.EqualTo(9));
        }
    }

    public class TomatoCondiment : IPizza
    {
        private readonly IPizza pizza;

        public TomatoCondiment(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public string GetLabel()
        {
            return string.Format("{0} with tomato", pizza.GetLabel());
        }

        public int GetPrice()
        {
            return pizza.GetPrice() + 2;
        }
    }

    public interface IPizza
    {
        string GetLabel();
        int GetPrice();
    }

    public class PlainPizza : IPizza
    {
        public string GetLabel()
        {
            return "Plain pizza";
        }

        public int GetPrice()
        {
            return 5;
        }
    }

    public class CheeseCondiment : IPizza
    {
        private readonly IPizza pizza;

        public CheeseCondiment(IPizza pizza)
        {
            this.pizza = pizza;
        }

        public string GetLabel()
        {
            return string.Format("{0} with cheese", pizza.GetLabel());
        }

        public int GetPrice()
        {
            return pizza.GetPrice() + 1;
        }
    }
}