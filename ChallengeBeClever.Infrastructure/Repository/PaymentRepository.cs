using ChallengeBeClever.Application.Interfaces;
using ChallengeBeClever.Domain.DataTranferObject;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;
using ChallengeBeClever.Application.UseCases.Payment.Get;

namespace ChallengeBeClever.Infrastructure.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DatabaseContext _context;
        public PaymentRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> AddPayment(PaymentPostRequestDTO data)
        {
            int id = 0;
            SqlConnection dbConnection = (SqlConnection)_context.Database.GetDbConnection();

            using (SqlCommand cmd = new SqlCommand("SP_Alta_Pago", dbConnection))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@EmployeeId", data.EmployeeId));
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@BusinessLocation", data.BusinessLocation));
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@RegisterType", data.RegisterType));
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@IVA", data.IVA));
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@Amount", data.Amount));
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@Date", data.Date));

                if (data.Interes != null)
                {
                    adapt.SelectCommand.Parameters.Add(new SqlParameter("@Interes", data.Interes));
                }
                if (data.Mora != null)
                {
                    adapt.SelectCommand.Parameters.Add(new SqlParameter("@Mora", data.Mora));
                }

                DataTable dt = new DataTable();
                adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        id = Convert.ToInt32(row["Id"]);
                    }
                }

                if (id != 0)
                {
                    return true;
                }

                return false;
            }
        }

        public async Task<PaymentGetResponse> ReportPayment(PaymentGetRequestDTO request)
        {
            SqlConnection dbConnection = (SqlConnection)_context.Database.GetDbConnection();

            PaymentGetResponse response = new PaymentGetResponse();

            using (SqlCommand cmd = new SqlCommand("SP_Payment_Report", dbConnection))
            {
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                adapt.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@DateFrom", request.DateFrom));
                adapt.SelectCommand.Parameters.Add(new SqlParameter("@DateTo", request.DateTo));

                DataTable dt = new DataTable();
                adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        response.AVGPayments = Convert.ToDecimal(row["AVGPayments"]);
                        response.Max = Convert.ToDateTime(row["Max"]);
                        response.Min = Convert.ToDateTime(row["Min"]);
                        response.TotalAmount = Convert.ToDecimal(row["Total"]);
                        response.TotalPayments = Convert.ToInt32(row["TotalPayments"]);

                    }
                }
                return response;
            }
        }
    }
}
