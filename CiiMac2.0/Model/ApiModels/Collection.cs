using Model.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Collection
    {
        [JsonProperty("customerNumber", Required = Required.Always)]
        public long CustomerNumber { get; set; }

        [JsonProperty("currency", Required = Required.Always)]
        public string Currency { get; set; }

        [JsonProperty("paymentTerms", Required = Required.Always)]
        public PaymentTerms PaymentTerms { get; set; }

        [JsonProperty("customerGroup", Required = Required.Always)]
        public CustomerGroup CustomerGroup { get; set; }

        [JsonProperty("address", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("balance", Required = Required.Always)]
        public double Balance { get; set; }

        [JsonProperty("dueAmount", Required = Required.Always)]
        public double DueAmount { get; set; }

        [JsonProperty("corporateIdentificationNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string CorporateIdentificationNumber { get; set; }

        [JsonProperty("city", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("email", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("zip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }

        [JsonProperty("vatZone", Required = Required.Always)]
        public VatZone VatZone { get; set; }

        [JsonProperty("lastUpdated", Required = Required.Always)]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("contacts", Required = Required.Always)]
        public Uri Contacts { get; set; }

        [JsonProperty("templates", Required = Required.Always)]
        public Templates Templates { get; set; }

        [JsonProperty("totals", Required = Required.Always)]
        public Invoices Totals { get; set; }

        [JsonProperty("deliveryLocations", Required = Required.Always)]
        public Uri DeliveryLocations { get; set; }

        [JsonProperty("invoices", Required = Required.Always)]
        public Invoices Invoices { get; set; }

        [JsonProperty("self", Required = Required.Always)]
        public Uri Self { get; set; }

        [JsonProperty("barred", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool? Barred { get; set; }

        [JsonProperty("creditLimit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? CreditLimit { get; set; }

        [JsonProperty("telephoneAndFaxNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TelephoneAndFaxNumber { get; set; }

        [JsonProperty("website", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Website { get; set; }

        [JsonProperty("layout", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Layout Layout { get; set; }
    }
}
