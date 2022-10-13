using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace BookMyMovieASP_MVC6.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        Db01Context db = new Db01Context();

        public Akbcustomer GetCustomerDetails(string Email)
        {
            try
            {
                var customer = db.Akbcustomers.Where(c => c.Email.ToLower().Equals(Email.ToLower())).FirstOrDefault();
                return customer;
            }
            catch (Exception Ex) {
                return null;
            }
            return null;
        }

        public bool RegisterCustomer(Akbcustomer customerDetails)
        {
            try
            {
                customerDetails.CustomerId = null;
				customerDetails.Password = EncodePasswordToBase64(customerDetails.Password);
				db.Akbcustomers.Add(customerDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool ValidateSignIn(string Email, string Password)
        {

			string encodedPassword = EncodePasswordToBase64(Password);
			Akbcustomer customerData = db.Akbcustomers
				.Where(c => c.Email.ToLower().Equals(Email) && c.Password.Equals(encodedPassword))
				.FirstOrDefault();

			return customerData != null;
		}

		public static string EncodePasswordToBase64(string password)
		{
			try
			{
				byte[] encData_byte = new byte[password.Length];
				encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
				string encodedData = Convert.ToBase64String(encData_byte);
				return encodedData;
			}
			catch (Exception ex)
			{
				throw new Exception("Error in base64Encode" + ex.Message);
			}
		}

		public string DecodeFrom64(string encodedData)
		{
			System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
			System.Text.Decoder utf8Decode = encoder.GetDecoder();
			byte[] todecode_byte = Convert.FromBase64String(encodedData);
			int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
			char[] decoded_char = new char[charCount];
			utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
			string result = new String(decoded_char);
			return result;
		}
	}
}
