using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceTIXMovie
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string transaksitiket(int IDFilm, string Bioskop, string NamaCustomer, string Phone, int Studio, string Tanggal, string JamTayang, string Row, string Seat, string Harga, string Total, string Status);
        [OperationContract]
        string edittransaksitiket(int IDTransaksi, string Status);
        [OperationContract]
        string deletetransaksitiket(string NamaCustomer);
        [OperationContract]
        string film(string JudulFilm, string Deskripsi, string Harga);
        [OperationContract]
        string editfilm(int id, string Harga);
        [OperationContract]
        string deletefilm(string JudulFilm);
        [OperationContract]
        string statustiket(int IDStatus, string IDTransaksi);

        [OperationContract]
        List<DataTransaksi> DataTransaksi();
        [OperationContract]
        List<DataFilm> DataFilm();
        [OperationContract]
        List<StatusTiket> StatusTiket();

        [OperationContract]
        string Login(string email, string password);
        [OperationContract]
        string Register(string username, string email, string phone, string password, string role);
        [OperationContract]
        List<DataRegister> DataRegist();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceTIXMovie.ContractType".
    [DataContract]
    public class DataTransaksi
    {
        [DataMember(Order = 1)]
        public int IDTransaksi { get; set; }
        [DataMember(Order = 2)]
        public int Film { get; set; } // Method
        [DataMember(Order = 3)]
        public string Bioskop { get; set; }
        [DataMember(Order = 4)]
        public string NamaCustomer { get; set; }
        [DataMember(Order = 5)]
        public string Phone { get; set; }
        [DataMember(Order = 6)]
        public int Studio { get; set; }
        [DataMember(Order = 7)]
        public string Tanggal { get; set; }
        [DataMember(Order = 8)]
        public string JamTayang { get; set; }
        [DataMember(Order = 9)]
        public string Row { get; set; }
        [DataMember(Order = 10)]
        public string Seat { get; set; }
        [DataMember(Order = 11)]
        public string Harga { get; set; }
        [DataMember(Order = 12)]
        public string Total { get; set; }
        [DataMember(Order = 13)]
        public string Status { get; set; }
    }

    [DataContract]
    public class DataFilm 
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string JudulFilm { get; set; }
        [DataMember(Order = 3)]
        public string Deskripsi { get; set; }
        [DataMember(Order = 4)]
        public string Harga { get; set; }
    }

    [DataContract]
    public class StatusTiket
    {
        [DataMember]
        public int IDStatus { get; set; }
        [DataMember]
        public string IDTransaksi { get; set; }
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string email { get; set; }
        [DataMember(Order = 4)]
        public string phone { get; set; }
        [DataMember(Order = 5)]
        public string password { get; set; }
        [DataMember(Order = 6)]
        public string role { get; set; }
    }
}
