using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Bloomberg API Namespaces
using Bloomberglp.Blpapi;
using EventHandler = Bloomberglp.Blpapi.EventHandler;

using DateTime = System.DateTime;
using DayOfWeek = System.DayOfWeek;
using Datetime = Bloomberglp.Blpapi.Datetime;
using Event = Bloomberglp.Blpapi.Event;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using Session = Bloomberglp.Blpapi.Session;


// Some of the Bloomberg services that we can work with include:
//blp/refdata  	Reference Data services including historical end of day, intra-day, OHLC bars
//blp/mktdata  	Steaming Market Data Services based on real-time or delayed market data feeds
//blp/mktvwap  	Custom Volume Weighted Average Price (VWAP) services based on real-time or delayed market data feeds
//blp/mktbar  	Intraday bars (pricing intervals) based on real-time or delayed market data feeds
//blp/apiflds  	Requests for metadata on API fields
//blp/tasvc      	Technical Analysis studies


// Event Status	Event Description
// SESSION_STATUS	Events contain information about the status of the session
// SERVICE_STATUS	Events contain information about the status of the Bloomberg service
// RESPONSE	Events containing the actual data in response to a Request
// SUBSCRIPTION_STATUS	Events contain information about the status of a subscription
// SUBSCRIPTION_DATA	Events contain data as per the subscriptions

namespace BloombergReaderConsole
{
    public class SimpleIntradayBarExample
    {
        public static void Main(string[] args)
        {
            SimpleIntradayBarExample example = new SimpleIntradayBarExample();
            example.run(args);
            System.Console.WriteLine("Press ENTER to quit");
            System.Console.Read();
        }

        private DateTime getPreviousTradingDate()
        {
            DateTime tradedOn = DateTime.Now;
            tradedOn = tradedOn.AddDays(-1);

            if (tradedOn.DayOfWeek == DayOfWeek.Sunday)
            {
                tradedOn = tradedOn.AddDays(-2);
            }
            else if (tradedOn.DayOfWeek == DayOfWeek.Saturday)
            {
                tradedOn = tradedOn.AddDays(-1);
            }
            return tradedOn;
        }

        private void run(string[] args)
        {
            string serverHost = "localhost";
            int serverPort = 8194;

            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = serverHost;
            sessionOptions.ServerPort = serverPort;

            System.Console.WriteLine("Connecting to " + serverHost + ":" + serverPort);
            Session session = new Session(sessionOptions);
            bool sessionStarted = session.Start();
            if (!sessionStarted)
            {
                System.Console.Error.WriteLine("Failed to start session.");
                return;
            }
            if (!session.OpenService("//blp/refdata"))
            {
                System.Console.Error.WriteLine("Failed to open //blp/refdata");
                return;
            }
            Service refDataService = session.GetService("//blp/refdata");
            Request request = refDataService.CreateRequest("IntradayBarRequest");
            request.Set("security", "IBM US Equity");
            request.Set("eventType", "TRADE");
            request.Set("interval", 60);	// bar interval in minutes
            DateTime tradedOn = getPreviousTradingDate();
            /*
            request.Set("startDateTime", new Datetime(tradedOn.Year,
                                                      tradedOn.Month,
                                                      tradedOn.Day,
                                                      13, 30, 0, 0));
            request.Set("endDateTime", new Datetime(tradedOn.Year,
                                                    tradedOn.Month,
                                                    tradedOn.Day,
                                                    21, 30, 0, 0));
            */
            request.Set("startDateTime", new Datetime(2015, 10, 01));
            request.Set("endDateTime", new Datetime(2015, 10, 02));

            System.Console.WriteLine("Sending Request: " + request);
            session.SendRequest(request, null);

            while (true)
            {
                Event eventObj = session.NextEvent();
                foreach (Message msg in eventObj)
                {
                    System.Console.WriteLine(msg);
                }
                if (eventObj.Type == Event.EventType.RESPONSE)
                {
                    break;
                }
            }
        }
    } 
}
