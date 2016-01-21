using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HotelRooms.encrypt;

namespace HotelRooms
{
    public class TravelAgency
    {
            public static Int32[] p;
            public static String[] hotels;
            public static String[] str=new String[30];
            public static int i=0;
            //Intializing the booked information array
            public void initialize()
            {
                for (int j = 0; j < 10; j++)
                    str[j] = "";
            }

            // Function to maintain the booked informaation till all the threads terminates
            public void maintainConfirmation(String s)
            {
                object o = str;
                Monitor.Enter(o);
                try
                {
                    str[i] = s;
                    i++;

                }
                finally
                {
                    
                    Monitor.Exit(o);
                    Thread.CurrentThread.Abort();   
                }
            }

            //Printing the booked information
            public void generateConfirmation()
            {

                for (int j = 0; j < i; j++)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    Console.WriteLine("                              BILL INFORMATION                                ");
                    Console.WriteLine("------------------------------------------------------------------------------");
                    String[] str1 = str[j].Split('/');
                    Console.WriteLine("Order Placed by      : {0}", str1[0]);
                    Console.WriteLine("Order Placed at      : {0}", str1[1]);
                    Console.WriteLine("No of Rooms Booked   : {0}", str1[2]);
                    Console.WriteLine("Total Bill Amount    : {0}", str1[3]);
                    Console.WriteLine("Start Time           : {0}", str1[4]);
                    Console.WriteLine("End Time             : {0}", str1[5]);
                    Console.WriteLine("Total Turnaround Time: {0}", str1[6]);
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
                //Thread.CurrentThread.Abort();
                
            }

        //display the hotel information initially
            public void agentFunc()
            {

                    HotelRooms.HotelSupplier rooms = new HotelRooms.HotelSupplier();
                
                    Thread.Sleep(1000);
                    p = rooms.getPrice();
                    hotels = rooms.getHotelNames();
                    Console.WriteLine("Hotel Information :");
                    for (int j = 0; j < 3; j++)
                    {
                        Console.WriteLine("Price of Hotel {0} is {1}", hotels[j], p[j]);
                    } 
            }

        // Handler function - Call back method
            public void roomOnSale(Int32 currentPrice, String hotelName)
            {
                Console.WriteLine("Room on Sale!");
                Console.WriteLine("Room price of {1} dropped to :{0}", currentPrice, hotelName);
                Console.WriteLine("No. of rooms available for this pricecut: {0}", NumberofRooms(hotelName));
                
                // Agent threads 
                Thread[] agencies = new Thread[5];
                String[] agencyName = { "Agency A", "Agency B", "Agency C", "Agency D", "Agency E" };
                for (int j = 0; j < 5; j++)
                {
                    agencies[j] = new Thread(new ParameterizedThreadStart(createOrder));
                    agencies[j].Name = agencyName[j];
                    agencies[j].Start(hotelName);
                }
   
            }

            //Encoding the detials to form a string
            public String encode(OrderObject o)
            {
                String str = o.getSenderId() + "/" + o.getRecieverId() + "/" + o.getAmount() + "/" + o.getCardNo()+"/"+o.getStartTime();
                return str;
            }

            //To create order for each agency
            public void createOrder(object hotel)
            {
                Random rng = new Random();
                ServiceClient encoder = new ServiceClient();
                String hotelName = hotel.ToString();
                Monitor.Enter(rng);
                try
                {
                    int noOfRooms = NumberofRooms(hotelName);  //To get no of rooms available

                    //Enters only if available rooms are > 2
                    if (noOfRooms > 2)
                    {
                        int orderRooms = rng.Next(2, noOfRooms); //Generates a random number to select rooms between 2 and max rooms available
                        int cardNo = rng.Next(5000, 8000); //To generate a card number between 5000 and 8000
                         Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                         Console.WriteLine("------------------------------------------------------------------------------");
                         Console.WriteLine("                              Order Inforamtion                                ");
                         Console.WriteLine("------------------------------------------------------------------------------");
                         Console.WriteLine("Order Placed by      : {0}", Thread.CurrentThread.Name);
                         Console.WriteLine("No of Rooms          : {0}", orderRooms);
                         Console.WriteLine("Card Number          : {0}", cardNo);
                         Console.WriteLine("Reciever ID          : {0}", hotelName);
                         Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        OrderObject constructOrder = new OrderObject();
                        constructOrder.setData(cardNo, orderRooms, hotelName); //Construct the order
                        String fullOrder = encode(constructOrder);  //Encodes the order
                        MultiCellBuffer.setOneCell(encoder.Encrypt(fullOrder));  //Using encrypt service
                       
                        //Calling hotelsupplier to process the order
                        HotelSupplier startOrder = new HotelSupplier();
                        startOrder.getOrder();
                    }
                }
                finally
                {
                    Monitor.Exit(rng);
                }
            }
    
            //Getting no of rooms depending on hotel name
            public int NumberofRooms(String hotelName)
            {
                   int noOfRooms = 0;
                   for (int i = 0; i < 3; i++)
                   {
                       if (HotelSupplier.bookRooms[i].hotelName.Equals(hotelName))
                           noOfRooms = HotelSupplier.bookRooms[i].noOfRooms;
                   }
                       return noOfRooms;
            }
}
}
