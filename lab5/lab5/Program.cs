using lab5.Subjects.Currency;
using lab5.Subjects.Currency.XmlCurrency;
using lab5.Subjects.Stock;

namespace lab5
{
    static class Program
    {
        private static void Main()
        {
            try
            {
                //creating subjects
                CurrencyRates currencyRates = new CurrencyRates(new WorkWithXml());
                GovernmentBondStockQuote governmentBondStockQuote =
                    new GovernmentBondStockQuote(1323146884.35, WayOfPaying.PostPaid);
                NaturalGasStockQuotes naturalGasStockQuotes =
                    new NaturalGasStockQuotes(10708.35, DeliveryConditions.Gts);

                //creating observers
                Observer user1 = new Observer("user1");
                Observer user2 = new Observer("user2");
                Observer user3 = new Observer("user3");

                //adding subscriptions
                user1.AddSubscriber(currencyRates);
                currencyRates.RegisterObserver(user2);
                user3.AddSubscriber(currencyRates);
                governmentBondStockQuote.RegisterObserver(user1);
                user2.AddSubscriber(governmentBondStockQuote);
                naturalGasStockQuotes.RegisterObserver(user2);
                user3.AddSubscriber(naturalGasStockQuotes);

                //sleep 1-2 sec and make changes
                Thread.Sleep(2000);
                governmentBondStockQuote.SetNewQuotedPrice(1329999999.35);
                Thread.Sleep(1000);
                naturalGasStockQuotes.SetNewQuotedPrice(10999);

                //removing subscriptions
                user1.RemoveSubscriber(currencyRates);
                governmentBondStockQuote.RemoveObserver(user2);
                user2.RemoveSubscriber(naturalGasStockQuotes);

                //make changes again
                governmentBondStockQuote.SetNewQuotedPrice(132888888888.35);
                naturalGasStockQuotes.SetNewQuotedPrice(10888);
                
                
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}