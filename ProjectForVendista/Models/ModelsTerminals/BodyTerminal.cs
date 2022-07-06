using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectForVendista.Models.ModelsTerminals

{
    public class BodyTerminal
    {
        public string bank_id { get; set; }

        public string serial_number { get; set; }

        public int? version { get; set; }

        public string gsm_operator { get; set; }

        public int? gsm_rssi { get; set; }

        public Int64 imei { get; set; }

        public int? partner_id { get; set; }

        public string partner_name { get; set; }

        public int? external_server_id { get; set; }

        public int? last_online_time { get; set; }

        public int? last24_hours_online { get; set; }

        public int? last_hour_online { get; set; }

        public int? last24_hours_packets_count { get; set; }

        public string sber_qrid { get; set; }

        public int? auto_cancel_timeout { get; set; }

        public float? bonus_percent { get; set; }

        public bool send_cash { get; set; }

        public bool send_cashless { get; set; }

        public int? type { get; set; }

        public int? sim_balance { get; set; }

        public string sim_number { get; set; }

        public int? division_id { get; set; }

        public int? bootloader_version { get; set; }

        public string comment { get; set; }

        public int? owner_id { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }

        public string owner_name { get; set; }

        public string color { get; set; }

        public int? sum { get; set; }

        public int? id { get; set; }

    }
}