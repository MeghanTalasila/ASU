using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace HotelRooms
{
    public class OrderObject
    {
        private string senderId;
        private string recieverId;
        private Int32 cardNo;
        private Int32 amount;
        private TimeSpan startTime;
        private TimeSpan endTime;
        private TimeSpan turnaroundTime;
       
        //set data methods
        public void setSenderId(String senderId)
        {
            this.senderId = senderId;
        }
        public void setRecieverId(String recieverId)
        {
            this.recieverId = recieverId;
        }
        public void setCardNo(Int32 cardNo)
        {
            this.cardNo = cardNo;
        }
        public void setAmount(Int32 amount)
        {
            this.amount = amount;
        }
        public void setStartTime(TimeSpan startTime)
        {
            this.startTime = startTime;
        }
        public void setEndTime(TimeSpan endTime)
        {
            this.endTime = endTime;
        }
        public void setTurnaroundTime(TimeSpan turnaroundTime)
        {
            this.turnaroundTime = turnaroundTime;
        }

        //get data methods
        public string getSenderId()
        {
            return(senderId);
        }
        public string getRecieverId()
        {
            return(recieverId);
        }
        public Int32 getCardNo()
        {
            return(cardNo);
        }
        public Int32 getAmount()
        {
            return(amount);
        }
        public TimeSpan getStartTime()
        {
            return startTime;
        }
        public TimeSpan getEndTime()
        {
            return endTime;
        }
        public TimeSpan getTurnaroundTime()
        {
            return turnaroundTime;
        }

        public void setData(Int32 num, Int32 noOfRooms, String hotelName)
        {
                cardNo = num;
                amount = noOfRooms;
                recieverId = hotelName;
                senderId = Thread.CurrentThread.Name;
                startTime = DateTime.Now.TimeOfDay;
        }
    }
}
