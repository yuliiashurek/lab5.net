namespace lab5.Subjects.Currency.XmlCurrency;

public static class XmlTagsInitializer
{
    private static XmlTags? _xmlTags;
    public static XmlTags GetXmlTags()
    {
        if (_xmlTags == null)
        {
            _xmlTags = new XmlTags(
                "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange",
                "/exchange/currency",
                "r030", "txt", "cc", "rate", "exchangedate",
                "dd.MM.yyyy");
        }
        return _xmlTags;
    }
}