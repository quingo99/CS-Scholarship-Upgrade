﻿using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace WCS.Models
{
    /// <summary>
    /// Wrapper of System.Security.Cryptography.SymmetricAlgorithm classes
    /// and the AES / Rijndael algorithm
    /// Written November 2004 by Lon Williams
    /// </summary>
    /// <remarks>
    /// AES A.K.A. Rijndael is the latest offering in advanced 
    /// cryptogrphy algorithms, offering up to a 256 secret key
    /// AES has been adopted as the next generation replacement
    /// for Triple DES.
    /// </remarks>
    /// <example> Encrypt and Decrypt a password using default key
    /// <code> 
    /// //Create crypto object using default (128) keys
    /// Crypto	crypto = new Crypto();
    /// string userPassword = "myPassword";
    /// string encryptedPassword = crypto.Encrypt(userPassword);
    /// string decryptedPassword = crypto.Decrypt(encryptedPassword);
    /// </code>
    /// </example>
    /// <modificationhistory><list type="table">
    /// <item><term>11/01/2004 - Lon Williams</term><description>Created</description></item>
    /// <item><term>02/28/2005 - Lon Williams</term><description>Thread safety and code review changes</description></item>
    /// <item><term>05/10/2005 - Lon Williams</term><description>Enhanced in-line remarks and documentation</description></item>
    /// </list></modificationhistory>


    public class Crypto
    {
        /// <summary>Length of the current crypto key</summary>
        public int CryptoKeyLength
        { get { return RijndaelProvider.Key.Length * 8; } }

        /// <summary>Private .NET provider for AES/Rijndael cryptography</summary>
        private RijndaelManaged RijndaelProvider;

        /// <remarks>
        /// Constructor for using RijndaelManaged cryptography 
        /// using default key length of 128
        /// </remarks>		
        public Crypto()
        {
            // Initialize crypto provider 
            RijndaelProvider = new RijndaelManaged();
            CreateDefaultKey(128);
        }
        /// <summary>
        /// Constructor for using RijndaelManaged cryptography
        /// Specify secret key length 128, 192, 256
        /// </summary>
        /// <param name="keyLength"></param>
        public Crypto(int keyLength)
        {
            RijndaelProvider = new RijndaelManaged();
            CreateDefaultKey(keyLength);
        }

        /// <summary>
        /// Constructor for using RijndaelManaged cryptography
        /// using pre-generated private keys
        /// </summary>
        /// <remarks>
        /// Private keys may be generated by using the generateSecretIV
        /// and generateSecretKey methods. The MEA-Admin tools contain
        /// a GenerateSecret.aspx page for this purpose.
        /// </remarks>
        /// <param name="IV">initialization vector</param>
        /// <param name="key">secret key</param>
        /// <example>Create Crypto object w/private pre-generated keys
        /// <code>
        /// string iv = DgCBZxjqHsAlGxsnrSy0kw==;
        /// string key = dizLFj4pwkuW4eKCVRkD8rFd178II21rU6D6S/1djHs=
        /// Crypto crypto = new Crypto(iv, key);
        /// string userPassword = "myPassword";
        /// string encryptedPassword = crypto.Encrypt(userPassword);
        /// string decryptedPassword = crypto.Decrypt(encryptedPassword);
        /// </code>
        /// </example>
        public Crypto(string IV, string key)
        {
            // Initialize crypto provider 
            RijndaelProvider = new RijndaelManaged();
            SetIV(IV);
            SetKey(key);
        }
        /// <summary>
        /// Set the default crypto key length
        /// </summary>
        /// <param name="cryptoKeyLength"></param>
        public void CreateDefaultKey(int cryptoKeyLength)
        {
            // set default valures for key an iv
            // these keys can be overriden by SetKey and SetIV methods

            string iv = "xKmu5cv6RFqC4+8AuY5UUw=="; // iv is always 128
            string key;
            RijndaelProvider.KeySize = cryptoKeyLength;

            switch (cryptoKeyLength)
            {
                case 256:
                    {
                        key = "B6fDATJo39wwxEtIwAeZL/lNAK9glBDvT5SS5U1gqU0=";
                        break;
                    }
                case 192:
                    {
                        key = "hQpkwEYzPxgIC5RZUwK491PKC8hPRg5Y";
                        break;
                    }
                default: // 128
                    {
                        key = "wR9pNI41OZUetzYVoqlCEg==";
                        break;
                    }
            }
            // generate a key from a Symetric Algorithm
            RijndaelProvider.Key = System.Convert.FromBase64String(key);
            RijndaelProvider.IV = System.Convert.FromBase64String(iv);
        }

        /// <summary>
        /// Encrypt a string and return a base64 encoded string
        /// </summary>
        /// <param name="originalString">String to encrypt</param>
        /// <returns>Encrypted string</returns>
        /// <example> Encrypt and Decrypt a password using default key
        /// <code> 
        /// //Create crypto object using default (128) keys
        /// Crypto	crypto = new Crypto();
        /// string userPassword = "myPassword";
        /// string encryptedPassword = crypto.Encrypt(userPassword);
        /// string decryptedPassword = crypto.Decrypt(encryptedPassword);
        /// </code>
        /// </example>
        public string Encrypt(string originalString)
        {
            byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(originalString);
            byte[] bytOut = null;

            // create a MemoryStream so that the process can be done without I/O files
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                // create an Encryptor from the Provider Service instance
                lock (RijndaelProvider)
                {
                    using (ICryptoTransform encrypto = RijndaelProvider.CreateEncryptor())
                    {
                        // create Crypto Stream that transforms a stream using the encryption
                        using (CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write))
                        {
                            // write out encrypted content into MemoryStream
                            cs.Write(bytIn, 0, bytIn.Length);
                            cs.FlushFinalBlock();
                        }
                    }
                }
                // get the output
                bytOut = ms.ToArray();
            }
            // convert into Base64 so that the result can be used in xml
            return Convert.ToBase64String(bytOut);
        }

        /// <summary>
        /// Decrypt a base64 encoded string and return original text
        /// </summary>
        /// <param name="encryptedString">string to decrypt</param>
        /// <returns>Decrypted string</returns>
        /// <example> Encrypt and Decrypt a password using default key
        /// <code> 
        /// //Create crypto object using default (128) keys
        /// Crypto	crypto = new Crypto();
        /// string userPassword = "myPassword";
        /// string encryptedPassword = crypto.Encrypt(userPassword);
        /// string decryptedPassword = crypto.Decrypt(encryptedPassword);
        /// </code>
        /// </example>
        public string Decrypt(string encryptedString)
        {

            try
            {            // convert from Base64 to binary
                string decryptedString = "";
                byte[] bytIn = Convert.FromBase64String(encryptedString);
                // create a MemoryStream with the input
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length))
                {
                    // create a Decryptor from the Provider Service instance
                    lock (RijndaelProvider)
                    {
                        using (ICryptoTransform encrypto = RijndaelProvider.CreateDecryptor())
                        {
                            // create Crypto Stream that transforms a stream using the decryption
                            using (CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read))
                            {
                                // read out the result from the Crypto Stream
                                using (System.IO.StreamReader sr = new System.IO.StreamReader(cs))
                                {
                                    // get the output and trim the '\0' bytes
                                    decryptedString = sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
                return decryptedString;
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// Generate a new secret key
        /// This method is used to generate a key that may be later passed to the constructor
        /// </summary>
        /// <returns></returns>
        public static string GenerateSecretKey(int keyLength)
        {
            string myKey = "";
            using (RijndaelManaged RJProvider = new RijndaelManaged())
            {
                RJProvider.KeySize = keyLength;
                RJProvider.GenerateKey();
                myKey = System.Convert.ToBase64String(RJProvider.Key, 0, RJProvider.Key.Length);
                RJProvider.Clear();
            }
            return myKey;
        }
        /// <summary>
        /// Generate a new secret initialization vector (IV) value
        /// </summary>
        /// <remarks>
        /// This method is used to generate a new initialization vector
        /// to be later passed to the constructor
        /// The IV value is a base64 encoded secret string used to 
        /// alter the repeating patterns in the first encoded block.
        /// Subsequent blocks are altered for pattern matching by 
        /// the previous block of data.
        /// </remarks>
        /// <returns>IV string</returns>
        public static string GenerateSecretIV()
        {
            string myIV = "";
            using (RijndaelManaged RJProvider = new RijndaelManaged())
            {
                RJProvider.GenerateIV();
                myIV = System.Convert.ToBase64String(RJProvider.IV, 0, RJProvider.IV.Length);
                RJProvider.Clear();
            }
            return myIV;

        }

        /// <summary>
        /// Manually set the secret key base64 string
        /// </summary>
        /// <param name="key">secret key for aes</param>
        public void SetKey(string key)
        {
            // Set the key.
            // this method will override the default iv value
            // generate a key from a Symetric Algorithm

            RijndaelProvider.Key = System.Convert.FromBase64String(key);
        }
        /// <summary>
        /// Manually set the secret IV base64 string 
        /// </summary>
        /// <param name="IV">init vector for aes</param>
        public void SetIV(string IV)
        {
            // Set the IV.
            // this method will override the default key values
            // generate a key from a Symetric Algorithm
            RijndaelProvider.IV = System.Convert.FromBase64String(IV);
        }
        /// <summary>
        /// Set key to a random one-time key w/system generated key and IV
        /// keyLength 128, 192, 256
        /// </summary>

        public void SetRandomKey(int keyLength)
        {
            // generate a key from a Symetric Algorithm

            RijndaelProvider.KeySize = keyLength;
            RijndaelProvider.GenerateKey();
            RijndaelProvider.GenerateIV();
        }
    }
}