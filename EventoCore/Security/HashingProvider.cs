using System.Security.Cryptography;
using System.Text;

namespace EventoCore.Security {

    public class HashingProvider {

        /*------------------------ FIELDS REGION ------------------------*/

        /*------------------------ METHODS REGION ------------------------*/
        public string ComputeHashFromStringToString(string valueToHash) {
            return Encoding.UTF8.GetString(
                SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(valueToHash))
            );
        }

    }

}
