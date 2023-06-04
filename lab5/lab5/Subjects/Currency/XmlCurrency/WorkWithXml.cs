// using System.Net;
using System.Xml;

namespace lab5.Subjects.Currency.XmlCurrency;

public class WorkWithXml
{
    private String _xmlData;
    public List<ICurrencyInfo> CurrencyInfos { get; private set; }
    private readonly XmlTags _xmlTags;
    private readonly XmlDocument _xmlDocument;

    public WorkWithXml()
    {
        _xmlDocument = new XmlDocument();
        _xmlTags = XmlTagsInitializer.GetXmlTags();
        _xmlData = RetrieveXmlData();
        CurrencyInfos = UpdateOurList(_xmlData);
        //Console.WriteLine(CurrencyInfos.ListOfCurrencyInfoToString());
    }

    public (bool, List<ICurrencyInfo>?) Reload()
    {
        string newData = RetrieveXmlData();
        if (newData != _xmlData)
        {
            _xmlData = newData;
            UpdateOurList(_xmlData);
            return (true, UpdateOurList(_xmlData));
        }

        Console.WriteLine("compared");
        return (false, null);
    }

    // private string RetrieveXmlData()
    // {
    //     string url = _xmlTags.Url;
    //     WebClient client = new WebClient();
    //     string res = client.DownloadString(url);
    //     return res;
    // }
    
    private string RetrieveXmlData()
    {
        string url = _xmlTags.Url;

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string xml = response.Content.ReadAsStringAsync().Result;
            return xml;
        }
    }

    public List<ICurrencyInfo> UpdateOurList(string xmlString)
    {
        List<ICurrencyInfo> currencyInfoList = new List<ICurrencyInfo>();

        _xmlDocument.LoadXml(xmlString);

        XmlNodeList? currencyNodes = _xmlDocument.SelectNodes(_xmlTags.XPathNodeIterate);

        if (currencyNodes != null)
            foreach (XmlNode currencyNode in currencyNodes)
            {
                string code = currencyNode.SelectSingleNode(_xmlTags.CodeXmlTag)?.InnerText ?? "no code";
                string name = currencyNode.SelectSingleNode(_xmlTags.CurrencyNameXmlTag)?.InnerText ?? "no name";
                string shortName = currencyNode.SelectSingleNode(_xmlTags.ShortCurrencyNameXmlTag)?.InnerText ??
                                   "no short name";
                decimal exchangeRate =
                    decimal.Parse(currencyNode.SelectSingleNode(_xmlTags.ExchangeRateXmlTag)?.InnerText ?? "0");
                DateTime dateTime =
                    DateTime.ParseExact(
                        currencyNode.SelectSingleNode(_xmlTags.LastUpdatedXmlTag)?.InnerText ??
                        DateTime.Now.ToString(_xmlTags.DateFormatInXml), _xmlTags.DateFormatInXml, null);

                CurrencyInfo currencyInfo = new CurrencyInfo(code, name, shortName, exchangeRate, dateTime);
                currencyInfoList.Add(currencyInfo);
            }

        CurrencyInfos = currencyInfoList;
        return currencyInfoList;
    }
}