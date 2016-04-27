using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainReservation
{
    public class Train
    {
        public string Name { get; set; }

        public List<Seat> Seats { get; set; }

        ////public Train()
        ////{
        ////    this.Seats = new List<Seat>();
        ////}
    }
}

//{
//"seats":
//    {
//    "1A":
//        {
//            "booking_reference": "",
//            "seat_number": "1",
//            "coach": "A"
//        },
//    "2A":
//        {
//            "booking_reference": "",
//            "seat_number": "2",
//            "coach": "A"
//        }
//    }
//}

//"page": 1,
//"total_pages": 8,
//"total_entries": 74,
//"q": "muse",
//"albums": [
//  {
//    "name": "Muse",
//    "permalink": "Muse",
//    "cover_image_url": "http://image.kazaa.com/images/69/01672812 1569/Yaron_Herman_Trio/Muse/Yaron_Herman_Trio-Muse_1.jpg",
//    "id": 93098,
//    "artist_nam e": "Yaron Herman Trio"
//  },