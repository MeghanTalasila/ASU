using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using HotelRooms.encrypt;

namespace HotelRooms
{
    //Delegaate for the pricecutEvent with price of the room and hotel name as parameters
    public delegate void priceCutEvent(Int32 pr, String hotelName);

    //Structure to store hotel information
    public struct myRoomInfo
    {
        public String hotelName;
        public int noOfRooms;
        public int amount;
    };

    //Initializing the hotel suppliers 
    public class HotelSupplier
    {
        static Random rng = new Random();
        public static event priceCutEvent priceCut;
        public static myRoomInfo[] bookRooms = new myRoomInfo[3];
        public Int32 flag = 0;
        public Int32 counter = 0;
        public static int noOfCurrentThreads = 0;
        public static void createTable()
        {


            String[] names = { "A", "B", "C" };
            int[] noOfRooms = { 200, 100, 150 };
            int[] price = { 100, 150, 112 };

            for (int i = 0; i < 3; i++)
            {

                bookRooms[i].hotelName = names[i];
                bookRooms[i].noOfRooms = noOfRooms[i];
                bookRooms[i].amount = price[i];

            }
        }

        //Recieves order from multi cell buffer and decodes the order and pass it to process order
        public void getOrder()
        {
            ServiceClient encoder = new ServiceClient();
            String orderInfo = "";
            OrderObject order = new OrderObject();

            orderInfo = MultiCellBuffer.getOneCell(); //Getting order from multi cell buffer

            order = decode(encoder.Decrypt(orderInfo)); //Making use of decrypt service
            
            processOrder(order);//Passing the order to process
        }

        //to decode the decrypted string
        public OrderObject decode(String orderInfo)
        {
            OrderObject order = new OrderObject();

            String[] orderdet = orderInfo.Split('/');

            order.setSenderId(orderdet[0]);
            order.setRecieverId(orderdet[1]);
            order.setAmount(int.Parse(orderdet[2]));
            order.setCardNo(int.Parse(orderdet[3]));
            order.setStartTime(TimeSpan.Parse(orderdet[4]));
            return order;
        }

        //To process the order and generate bill
        public void processOrder(OrderObject order)
        {
            //Checks for the validity of the card
            if (order.getCardNo() > 5000 && order.getCardNo() < 7000)
            {
                Int32 pri = 0;
                int flag = 0;
                // Process the order only if rooms are available
                for (int k = 0; k < 3; k++)
                {
                    if ((bookRooms[k].hotelName).Equals(order.getRecieverId()))
                    {

                        if (bookRooms[k].noOfRooms >= order.getAmount())
                        {
                            flag = 1;
                            bookRooms[k].noOfRooms -= order.getAmount();
                        }
                        pri = bookRooms[k].amount;
                        break;

                    }
                }

                double totalAmount = 0;
                
                // If rooms are available generates confiramtion message
                if (flag == 1)
                {
                    flag = 0;
                    totalAmount = pri * order.getAmount();
                    totalAmount += 0.05 * totalAmount;
                    String eConfirm = order.getSenderId() + "/" + order.getRecieverId() + "/" + order.getAmount() + "/" + totalAmount;
                    TravelAgency confirmation = new TravelAgency();
                    
                    //To calculate the order completion time and turn around time
                    order.setEndTime(DateTime.Now.TimeOfDay);
                    order.setTurnaroundTime(order.getEndTime() - order.getStartTime());

                    //Constructing string for confirmation
                    eConfirm += "/" + order.getStartTime()+"/" +order.getEndTime()+"/" +order.getTurnaroundTime().TotalMilliseconds;
                    confirmation.maintainConfirmation(eConfirm);

                }

            }
        }

        //To retrieve price information for a hotel
        public Int32[] getPrice()
        {
            Int32[] pris = { 0, 0, 0 };
            int i = 0;
            for (int k = 0; k < 3; k++)
            {
                pris[k] = bookRooms[k].amount;
            }
            return pris;
        }

        //To retrieve hotel names
        public String[] getHotelNames()
        {
            String[] hotels = { "", "", "" };

            for (int i = 0; i < 3; i++)
            {
                hotels[i] = bookRooms[i].hotelName;

            }
            return hotels;
        }

        //Calling the price cut event whenever current price is less than prev price
        public void changePrice(Int32 prevPrice, Int32 currentPrice, String hotelName)
        {
            if (currentPrice < prevPrice)
            {
                counter++; //To track number of price cut events happend for each thread
                if (counter > 10)
                {
                    Console.WriteLine("10 or more price cut events have occured. The thread {0} is terminating", Thread.CurrentThread.Name);
                    noOfCurrentThreads++;
                    Thread.CurrentThread.Abort();
                }
                if (priceCut != null)
                {
                    priceCut(currentPrice, hotelName); //Price cut event is called
                }
            }
        }

        //Generate price 
        public void supplierFunc()
        {
            Int32 currentPrice = 0;
            Int32 prevPrice = 0;
            object o = currentPrice;
            String hotelName = "";
            for (int i = 0; i <= 50; i++)
            {
                Monitor.Enter(o);
                try
                {
                    Thread.Sleep(500);

                    currentPrice = rng.Next(30, 500);   // to generate prices - Pricing Model

                    hotelName = Thread.CurrentThread.Name;

                    //To find the previous price of each hotel
                    for (int k = 0; k < 3; k++)
                    {

                        if ((bookRooms[k].hotelName).Equals(hotelName))
                        {
                            prevPrice = bookRooms[k].amount;
                            bookRooms[k].amount = currentPrice;
                            break;
                        }
                    }

                    changePrice(prevPrice, currentPrice, hotelName); //calls the function to generate price cut event if price is lower that previous price

                }
                finally
                {

                    Monitor.Exit(o);
                }
            }
        }
    }

}