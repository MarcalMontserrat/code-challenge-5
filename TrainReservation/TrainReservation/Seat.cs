using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation
{
    public class Seat
    {
        public string Coach { get; set; }

        public string Seat_Number { get; set; }

        public string booking_reference { get; set; }

        public string GetName()
        {
            return this.Seat_Number + this.Coach;
        }

        //public Seat(string coach, int seatNumber)
        //{
        //    this.Coach = coach;
        //    this.SeatNumber = seatNumber;
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        //public override bool Equals(object obj)
        //{
        //    Seat seat = obj as Seat;
        //    if (this.Coach == seat.Coach)
        //        return this.SeatNumber == seat.SeatNumber;
        //    else
        //        return false;
        //}
    }
}