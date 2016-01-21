using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HotelRooms
{
    public class MultiCellBuffer
    {
            public static ReaderWriterLock rwl = new ReaderWriterLock(); //read write lock to synchronize the threads for r-r and w-r overlap
            public static Semaphore read = new Semaphore(0,3); //To maintain track of buffer cells
            public static Semaphore write = new Semaphore(3, 3); //To maintain track of buffer cells

            // 3 cells for the multi-cell buffer
            public static String buffer1 = "";
            public static String buffer2 = "";
            public static String buffer3 = "";
            
            //Write data to cell
            public static void setOneCell(String s)
            {
                rwl.AcquireWriterLock(Timeout.Infinite);
                try
                {
                    write.WaitOne();
                    if (buffer1.Equals(""))
                        buffer1 = s;
                    else if (buffer2.Equals(""))
                        buffer2 = s;
                    else if (buffer3.Equals(""))
                        buffer3 = s;
                    else
                        setOneCell(s);
                    read.Release();
                }
                finally
                {
                    rwl.ReleaseWriterLock();
                }

            }


            //read data from cell
            public static String getOneCell()
            {
                rwl.AcquireReaderLock(Timeout.Infinite);
                String info = "";
                try
                {
                    read.WaitOne();
                    if (!buffer1.Equals(""))
                    {
                        info = buffer1;
                        buffer1 = "";

                    }
                    else if (!buffer2.Equals(""))
                    {
                        info = buffer2;
                        buffer2 = "";

                    }
                    else if (!buffer3.Equals(""))
                    {
                        info = buffer3;
                        buffer3 = "";

                    }
                    else
                        getOneCell();
                    write.Release();
                }
                finally
                {
                    rwl.ReleaseReaderLock();
                }
                return info;
            }
    }
}
