using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Services
{

    public interface ITokenService
    {
        #region Interface member methods.
        /// &lt;summary>
        ///  Function to generate unique token with expiry against the provided userId.
        ///  Also add a record in database for generated token.
        /// &lt;/summary>
        /// &lt;param name="userId">&lt;/param>
        /// &lt;returns>&lt;/returns>
        Tokens GenerateToken(int userId);

        /// &lt;summary>
        /// Function to validate token againt expiry and existance in database.
        /// &lt;/summary>
        /// &lt;param name="tokenId">&lt;/param>
        /// &lt;returns>&lt;/returns>
        bool ValidateToken(string tokenId);

        /// &lt;summary>
        /// Method to kill the provided token id.
        /// &lt;/summary>
        /// &lt;param name="tokenId">&lt;/param>
        bool Kill(string tokenId);

        /// &lt;summary>
        /// Delete tokens for the specific deleted user
        /// &lt;/summary>
        /// &lt;param name="userId">&lt;/param>
        /// &lt;returns>&lt;/returns>
        bool DeleteByUserId(int userId);
        #endregion
    }
}

