using System;
using System.Xml;

public class PaymentsSaver
{

    public static void Payments()
    {

        // Create the XmlDocument.
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<item><name>ELEMENT</name></item>");

        // Add a price element.
        XmlElement newElem = doc.CreateElement("CENA");
        newElem.InnerText = "10.95";
        doc.DocumentElement.AppendChild(newElem);

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        // Save the document to a file and auto-indent the output.
        XmlWriter writer = XmlWriter.Create("data.xml", settings);
        doc.Save(writer);
    }
    public static float CalculatePrice(float price, int persons, float discount, float[] additionals)
    {
        //cena bazowa za sam pokój o danym standardzie z ewentualną zniżką w %
        var TotalPrice = price * persons * discount;
        
        //dodatki wedle checkboxów powinny się dorzucić do listy
        foreach (var item in additionals)
        {
            TotalPrice += item;
        }

        return TotalPrice;
        
    }
}