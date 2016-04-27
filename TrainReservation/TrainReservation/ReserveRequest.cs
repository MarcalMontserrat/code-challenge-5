using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation
{
    internal class ReserveRequest
    {
        public string train_id { get; set; }
        public string booking_reference { get; set; }
        public List<string> seats { get; set; }

        //{"train_id": "express_2000", "booking_reference": "75bcd15", "seats": ["1A", "1B"]}
    }
}