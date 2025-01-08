using Invoicer.Models;
using Invoicer.Services;

namespace Invoicer.Console
{
    public class Process
    {
        public void Go()
        {
            new InvoicerApi(SizeOption.A4, OrientationOption.Portrait, "£")
                .TextColor("#CC0000")
                .BackColor("#FFD6CC")
                .Image(@"images\vodafone.jpg", 125, 27)
                .Company(Address.Make("FROM", new string[] { "Vodafone Limited", "Vodafone House", "The Connection", "Newbury", "Berkshire RG14 2FN" }, "1471587", "569953277"))
                .Client(Address.Make("BILLING TO", new string[] { "Isabella Marsh", "Overton Circle", "Little Welland", "Worcester", "WR## 2DJ" }))
                .Items([
                    ItemRow.Make("Nexus 6", "Midnight Blue", 1, 20, (decimal)166.66, (decimal)199.99),
                    ItemRow.Make("24 Months (£22.50pm)", "100 minutes, Unlimited texts, 100 MB data 3G plan with 3GB of UK Wi-Fi", 1, 20, (decimal)360.00, (decimal)432.00),
                    ItemRow.Make("Special Offer", "Free case (blue)", 1, 0, 0, 0),
                ])
                .Totals([
                    TotalRow.Make("Sub Total", (decimal)526.66),
                    TotalRow.Make("VAT @ 20%", (decimal)105.33),
                    TotalRow.Make("Total", (decimal)631.99, true),
                ])
                .Details([
                    DetailRow.Make("PAYMENT INFORMATION", "Make all cheques payable to Vodafone UK Limited.", "", "If you have any questions concerning this invoice, contact our sales department at sales@vodafone.co.uk.", "", "Thank you for your business.")
                ])
                .Footer("http://www.vodafone.co.uk")
                .Save();
        }
    }
}
