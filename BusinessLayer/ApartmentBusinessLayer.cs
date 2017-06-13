using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ApartmentDomain;
using System.Web;

namespace ApartmentBusinessLayer
{
    public class ApartmentBusinessLayer : IApartmentInterface, IBookingInterface
    {
        public IEnumerable<Address> Apartments()
        {
            List<Address> apartments = new List<Address>();
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Address apartment = new Address();
                    apartment.address_ID = Convert.ToInt32(sdr["address_ID"]);
                    apartment.FlatNumber = Convert.ToInt32(sdr["address_FlatNumber"]);
                    apartment.HouseName = sdr["address_HouseName"].ToString();
                    apartment.NumberOfRooms = Convert.ToInt32(sdr["address_NumberOfRooms"]);
                    apartment.DescriptionOfRoom = sdr["address_DescriptionOfRoom"].ToString();
                    apartment.InitialRent = Convert.ToDouble(sdr["address_Rent"]);
                    apartment.InitialDeposit = Convert.ToDouble(sdr["address_Deposit"]);
                    apartment.IsRoomAvailable = Convert.ToBoolean(sdr["address_IsRoomAvailable"]);
                    apartment.OwnerID = Convert.ToInt32(sdr["address_OwnerID"]);
                    apartment.Photos = sdr["address_Photos"].ToString();
                    apartment.Street = sdr["address_Street"].ToString();
                    apartment.City = sdr["address_City"].ToString();
                    apartment.Country = sdr["address_Country"].ToString();
                    apartment.ZipCode = sdr["address_ZipCode"].ToString();

                    apartments.Add(apartment);
                }
            }
            return apartments;
        }

        public void RegisterApartmentAddress(Address address)
        {            
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter FlatNumber = new SqlParameter("@address_FlatNumber", HttpUtility.HtmlEncode(address.FlatNumber));
                cmd.Parameters.Add(FlatNumber);

                SqlParameter HouseName = new SqlParameter("@address_HouseName", HttpUtility.HtmlEncode(UtilityClass.IsNullable(address.HouseName)));
                cmd.Parameters.Add(HouseName);

                SqlParameter NumberOfRooms = new SqlParameter("@address_NumberOfRooms", HttpUtility.HtmlEncode(address.NumberOfRooms));
                cmd.Parameters.Add(NumberOfRooms);
                
                SqlParameter DescriptionOfRoom = new SqlParameter("@address_DescriptionOfRoom", HttpUtility.HtmlEncode(address.DescriptionOfRoom));
                cmd.Parameters.Add(DescriptionOfRoom);

                SqlParameter InitialRent = new SqlParameter("address_Rent", HttpUtility.HtmlEncode(address.InitialRent));
                cmd.Parameters.Add(InitialRent);

                SqlParameter InitialDeposit = new SqlParameter("@address_Deposit", HttpUtility.HtmlEncode(address.InitialDeposit));
                cmd.Parameters.Add(InitialDeposit);

                SqlParameter IsRoomAvailable = new SqlParameter("@address_IsRoomAvailable", HttpUtility.HtmlEncode(address.IsRoomAvailable));
                cmd.Parameters.Add(IsRoomAvailable);

                SqlParameter OwnerID = new SqlParameter("@address_OwnerID", Convert.ToInt32(HttpContext.Current.Session["PersonID"]));
                cmd.Parameters.Add(OwnerID);

                //SqlParameter Photos = new SqlParameter("@address_Photos", address.Photos);
                //cmd.Parameters.Add(Photos);

                SqlParameter Street = new SqlParameter("@address_Street", HttpUtility.HtmlEncode(UtilityClass.IsNullable(address.Street)));
                cmd.Parameters.Add(Street);

                SqlParameter City = new SqlParameter("@address_City", HttpUtility.HtmlEncode(address.City));
                cmd.Parameters.Add(City);

                SqlParameter Country = new SqlParameter("@address_Country ", HttpUtility.HtmlEncode(address.Country));
                cmd.Parameters.Add(Country);

                SqlParameter ZipCode = new SqlParameter("@address_ZipCode", HttpUtility.HtmlEncode(UtilityClass.IsNullable(address.ZipCode)));
                cmd.Parameters.Add(ZipCode);



                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateApartmentAddress(Address address)
        {
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter AddressID = new SqlParameter("@address_ID", HttpUtility.HtmlEncode(address.address_ID));
                cmd.Parameters.Add(AddressID);

                SqlParameter FlatNumber = new SqlParameter("@FlatNumber", HttpUtility.HtmlEncode(address.FlatNumber));
                cmd.Parameters.Add(FlatNumber);

                SqlParameter HouseName = new SqlParameter("@HouseName", HttpUtility.HtmlEncode(address.HouseName));
                cmd.Parameters.Add(HouseName);

                SqlParameter NumberOfRooms = new SqlParameter("@address_NumberOfRooms", HttpUtility.HtmlEncode(address.NumberOfRooms));
                cmd.Parameters.Add(NumberOfRooms);

                SqlParameter DescriptionOfRoom = new SqlParameter("@DescriptionOfRoom", HttpUtility.HtmlEncode(address.DescriptionOfRoom));
                cmd.Parameters.Add(DescriptionOfRoom);

                SqlParameter IsRoomAvailable = new SqlParameter("@IsRoomAvailable", HttpUtility.HtmlEncode(address.IsRoomAvailable));
                cmd.Parameters.Add(IsRoomAvailable);

                SqlParameter Photos = new SqlParameter("@Photos", HttpUtility.HtmlEncode(UtilityClass.IsNullable(address.Photos)));
                cmd.Parameters.Add(Photos);
                SqlParameter Street = new SqlParameter("@Street", HttpUtility.HtmlEncode(address.Street));
                cmd.Parameters.Add(Street);

                SqlParameter City = new SqlParameter("@City", HttpUtility.HtmlEncode(address.City));
                cmd.Parameters.Add(City);

                SqlParameter Country = new SqlParameter("@Country", HttpUtility.HtmlEncode(address.Country));
                cmd.Parameters.Add(Country);

                SqlParameter ZipCode = new SqlParameter("@address_ID", HttpUtility.HtmlEncode(address.ZipCode));
                cmd.Parameters.Add(ZipCode);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteApartment(int AddressID)
        {
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter addressID = new SqlParameter("@address_ID", HttpUtility.HtmlEncode(AddressID));
                cmd.Parameters.Add(addressID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public double BookingDetails(int AddressID)
        {
            BookingDetails bookingDetails = new ApartmentDomain.BookingDetails();
            string connectionString = UtilityClass.connectionString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetApartmentRent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@AddressID", HttpUtility.HtmlEncode(AddressID));
                cmd.Parameters.Add("@Rent", SqlDbType.Int).Direction = ParameterDirection.Output;

                con.Open();
                cmd.ExecuteNonQuery();

                double Rent = double.Parse(cmd.Parameters["@Rent"].Value.ToString());

                return Rent;
            }
                        
        }

        public void RegisterBooking(BookingDetails bookingDetails)
        {
            int AddressID = Convert.ToInt32(HttpContext.Current.Session["AddressID"]);
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spFinalRentAfterDiscounts", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter PersonID = new SqlParameter("@finalRent_PersonID", Convert.ToInt32(HttpContext.Current.Session["PersonID"]));
                cmd.Parameters.Add(PersonID);

                SqlParameter AddressId = new SqlParameter("@finalRent_AddressID", HttpUtility.HtmlEncode(AddressID));
                cmd.Parameters.Add(AddressId);

                SqlParameter BookingDate = new SqlParameter("@booking_BookingDate", DateTime.Now);
                cmd.Parameters.Add(BookingDate);

                SqlParameter MoveInDate = new SqlParameter("@booking_MoveInDate", HttpUtility.HtmlEncode(bookingDetails.MoveInDate));
                cmd.Parameters.Add(MoveInDate);

                SqlParameter MoveOutDate = new SqlParameter("@booking_MoveOutDate", HttpUtility.HtmlEncode(bookingDetails.MoveOutDate));
                cmd.Parameters.Add(MoveOutDate);

                double discountPercent = UtilityClass.DiscountPercent(DateTime.Now, bookingDetails.MoveInDate);
                SqlParameter DiscountPercent = new SqlParameter("@finalRent_DiscountPercent", HttpUtility.HtmlEncode(discountPercent));
                cmd.Parameters.Add(DiscountPercent);

                SqlParameter FinalRent = new SqlParameter("@finalRent_FinalRent", HttpUtility.HtmlEncode(UtilityClass.FinalRent(GetRent(AddressID), discountPercent)));
                cmd.Parameters.Add(FinalRent);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static double GetRent(int AddressID)
        {
            ApartmentBusinessLayer apartmentBusinessLayer = new ApartmentBusinessLayer();
            return apartmentBusinessLayer.BookingDetails(AddressID);            
        }

        public IEnumerable<RentDetails> GetApartmentRent()
        {
            List<RentDetails> rentDetails = new List<RentDetails>();
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetRent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    RentDetails rentDetail = new RentDetails();
                    rentDetail.FlatNumber = Convert.ToInt32(sdr["address_FlatNumber"]);
                    rentDetail.HouseName = sdr["address_HouseName"].ToString();
                    rentDetail.address_ID = Convert.ToInt32(sdr["rent_AddressID"]);
                    rentDetail.Rent = Convert.ToDouble(sdr["rent_Rent"]);
                    rentDetail.Deposit = Convert.ToDouble(sdr["rent_Deposit"]);
                    
                    rentDetails.Add(rentDetail);
                }
            }
            return rentDetails;
        }

        public IEnumerable<FinalRentDetails> FinalRentDetails()
        {
            List<FinalRentDetails> finalRentDetails = new List<ApartmentDomain.FinalRentDetails>();
            string connectionString = UtilityClass.connectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetFullRentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    FinalRentDetails finalRentDetail = new ApartmentDomain.FinalRentDetails();
                    finalRentDetail.PersonID = Convert.ToInt32(sdr["booking_PersonID"]);
                    finalRentDetail.AddressID = Convert.ToInt32(sdr["address_ID"]);
                    finalRentDetail.FlatNumber = Convert.ToInt32(sdr["address_FlatNumber"]);
                    finalRentDetail.HouseName = sdr["address_HouseName"].ToString();
                    finalRentDetail.BookingDate = Convert.ToDateTime(sdr["booking_BookingDate"]);
                    finalRentDetail.MoveInDate = Convert.ToDateTime(sdr["booking_MoveInDate"]);
                    finalRentDetail.MoveOutDate = Convert.ToDateTime(sdr["booking_MoveOutDate"]);
                    finalRentDetail.Rent = Convert.ToDouble(sdr["rent_Rent"]);
                    finalRentDetail.Deposit = Convert.ToDouble(sdr["rent_Deposit"]);
                    finalRentDetail.DiscountPercent = Convert.ToDouble(sdr["finalRent_DiscountPercent"]);
                    finalRentDetail.FinalRent = Convert.ToDouble(sdr["finalRent_FinalRent"]);

                    finalRentDetails.Add(finalRentDetail);
                }
            }
            return finalRentDetails;
        }
    }
}