using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.ComponentModel;
namespace HotelRooms
{   
    public class MyApplication
    {
        static TravelAgency agency = new TravelAgency(); 
        static void Main(string[] args)
        {
            // Objects of the hotel supplier class
            HotelSupplier[] rooms= new HotelSupplier[3];

            //Intializing the hotel supplier objects
            HotelSupplier.createTable();

            //Intialize the confirmation string
            agency.initialize();

            //Displaying hotel inforamtion initially
            agency.agentFunc();

            //Background thread monitoring whether all the threads have been terminated or not
            Thread terminator = new Thread(new ThreadStart(checkrunningthreads));
            terminator.Start();

           
            //Hotel Supplier threads
            Thread[] supplier = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                rooms[i] = new HotelSupplier();
                supplier[i] = new Thread(new ThreadStart(rooms[i].supplierFunc));
                supplier[i].Name = HotelSupplier.bookRooms[i].hotelName;
                supplier[i].Start();
            }
           
            //Adding travel agency class to the price cut event
            Monitor.Enter(agency);
            try
            {
               HotelSupplier.priceCut += new priceCutEvent(agency.roomOnSale);
            }
            finally
            {
                Monitor.Exit(agency);
            }
           
        }

        //Generates confirmation after all the hotel supplier threads are terminated
        static public void checkrunningthreads()
        {
            while (HotelSupplier.noOfCurrentThreads != 3) { }
            agency.generateConfirmation();
        }
    }
}
