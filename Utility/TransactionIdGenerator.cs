namespace Moonwalkers.Utility
{
    public class TransactionIdGenerator
    {
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

    }
}
