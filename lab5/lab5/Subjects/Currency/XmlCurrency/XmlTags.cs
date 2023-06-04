namespace lab5.Subjects.Currency.XmlCurrency;

public class XmlTags
{
    
    public string Url { get; }
    public string XPathNodeIterate { get; }
    public string CodeXmlTag { get; }
    public string CurrencyNameXmlTag { get; }
    public string ShortCurrencyNameXmlTag { get; }
    public string ExchangeRateXmlTag { get; }
    public string LastUpdatedXmlTag { get; }
    public string DateFormatInXml { get; }
    
    public XmlTags(string url, string xPathNodeIterate, string codeXmlTag, string currencyNameXmlTag, string shortCurrencyNameXmlTag, string exchangeRateXmlTag, string lastUpdatedXmlTag, string dateFormatInXml)
    {
        Url = url;
        XPathNodeIterate = xPathNodeIterate;
        CodeXmlTag = codeXmlTag;
        CurrencyNameXmlTag = currencyNameXmlTag;
        ShortCurrencyNameXmlTag = shortCurrencyNameXmlTag;
        ExchangeRateXmlTag = exchangeRateXmlTag;
        LastUpdatedXmlTag = lastUpdatedXmlTag;
        DateFormatInXml = dateFormatInXml;
    }

}