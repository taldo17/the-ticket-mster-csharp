using System;
using System.Text;

namespace Ticket_Master
{
    public class TicketService
    {
        private WindowsFileWriter _windowsFileWriter = new WindowsFileWriter();
        private const int CancellationTimeInDays = 7;
        public static int OrdersCounter = 0;

    public string PlaceOrder(string showName, string desiredDateStr, int numberOfTickets)
    {
        var desiredDate = DateTime.Parse(desiredDateStr);
        var currentDate = DateTime.Now;
            ValidateDates(desiredDate, currentDate);
            DateTime lastCancellationDate = DateTime.MinValue;
            if (isMoreThanAWeek(desiredDate, currentDate))
            {
                lastCancellationDate = setCancellationDate(currentDate);
            }
            string reportString = GenerateReportString(showName, desiredDateStr, numberOfTickets, lastCancellationDate);
            _windowsFileWriter.Write(reportString);
            S3TicketsDao.GetInstance().UploadObject(reportString);
            OrdersCounter++;
            return reportString;

        }

        private DateTime setCancellationDate(DateTime currentDate)
        {
            DateTime localDate = currentDate.AddDays(CancellationTimeInDays);
            return localDate;
        }

        private string GenerateReportString(string showName, string desireDate, int numberOfTickets, DateTime lastCancellationDate)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order report:");
            sb.Append("\n");
            sb.Append("Show name: " + showName);
            sb.Append("\n");
            sb.Append("Desired date: " + desireDate);
            sb.Append("\n");
            sb.Append("Number of tickets: " + numberOfTickets);
            sb.Append("\n");
            sb.Append("Last cancellation Date: " + FormatDate(lastCancellationDate));
            sb.Append("\n");
            return sb.ToString();
        }

        private void ValidateDates(DateTime desiredDate, DateTime date)
        {
            if (desiredDate < date)
            {
                throw new Exception("Desired date has already passed");
            }
        }

        private String FormatDate(DateTime date)
        {
            return date != DateTime.MinValue ? date.ToShortDateString(): "None";
        }

        private bool isMoreThanAWeek(DateTime desiredDate, DateTime currentDate)
        {
            return (desiredDate - currentDate).Days > 7;
        }

    }
}