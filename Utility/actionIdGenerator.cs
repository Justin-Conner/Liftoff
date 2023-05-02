namespace Moonwalkers.Utility
{
    public class actionIdGenerator
    {
        public int? productId { get; set; }
        public string GenerateTransactionId(int productId, int supplierId, DateTime timestamp, int transactionTypeId)
        {
            // Convert product ID and supplier ID to three-digit strings
            string productIdString = productId.ToString("D3");
            string supplierIdString = supplierId.ToString("D3");

            // Convert datetime timestamp to a string in the format "yyyyMMddHHmmssfff"
            string timestampString = timestamp.ToString("yyyyMMddHHmmssfff");

            // Combine all parts into a single string
            string transactionId = productIdString + supplierIdString + timestampString + transactionTypeId;

            return transactionId;
        }
       /* int productId = 123;
        int supplierId = 456;
        DateTime timestamp = DateTime.UtcNow;
        int transactionTypeId = 1;*/

      //  string transactionId = GenerateTransactionId(productId, supplierId, timestamp, transactionTypeId);


    }
}
