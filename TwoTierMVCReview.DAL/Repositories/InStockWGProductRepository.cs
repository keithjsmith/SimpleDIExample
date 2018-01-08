using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTierMVCReview.DAL.Repositories
{
    public class InStockWGProductRepository : IWGProductRepository
    {
        public void Add(WGProduct entity)
        {
            throw new NotImplementedException();
        }

        public WGProduct Find(int? Id)
        {
            throw new NotImplementedException();
        }

        public List<WGProduct> GetAll()
        {

            //Can create a whole new set of functionality here that
            //goes to a test database instead, uses connected sql, calls
            //to a WebAPI for data instead.

            //1) create connection
            SqlConnection conn = new SqlConnection(
                @"Data Source = .\sqlexpress; Initial Catalog = ZMovies; " +
                "Integrated Security = true;");

            //2) open connection
            conn.Open();

            //3) create the sql command
            SqlCommand cmdGetProdInfo = new SqlCommand(
                @"SELECT * FROM WGProducts where ProdStatusID = 1", conn);

            //4) execute the command 
            SqlDataReader rdrProducts = cmdGetProdInfo.ExecuteReader();

            List<WGProduct> inStockProducts = new List<WGProduct>();

            while (rdrProducts.Read())
            {
                inStockProducts.Add(new WGProduct()
                {
                    ProdName = rdrProducts["ProdName"].ToString(),
                    Description = rdrProducts["Description"].ToString(),
                    Price = Convert.ToDecimal(rdrProducts["Price"]),
                    ImageURL = rdrProducts["ImageURL"].ToString(),
                    CategoryID = Convert.ToInt32(rdrProducts["CategoryID"]),
                    ProdStatusID = Convert.ToInt32(rdrProducts["ProdStatusID"]),
                    VendorID = Convert.ToInt32(rdrProducts["VendorID"])
                });
            }

            //5) close everything
            rdrProducts.Close();
            conn.Close();
            return inStockProducts;
        }

        public void Remove(WGProduct entity)
        {
            throw new NotImplementedException();
        }

        public void Update(WGProduct entity)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LimitedWGProductRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
