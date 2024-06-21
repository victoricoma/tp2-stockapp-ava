using StockApp.Application.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Threading;

namespace StockApp.Application.Services
{
    public class MfaService : IMfaService
    {
        private readonly ConcurrentDictionary<string, string> otpCache = new ConcurrentDictionary<string, string>();

        public string GenerateOtp()
        {
            var otp = new Random().Next(100000, 999999).ToString();
            return otp;
        }

        public bool ValidateOtp(string userOtp, out string storedOtp)
        {
            storedOtp = string.Empty;

            foreach (var otpEntry in otpCache)
            {
                if (otpEntry.Value == userOtp)
                {
                    storedOtp = otpEntry.Value;
                    return true;
                }
            }
            return false;
        }


        public void StoreOtp(string key, string otp)
        {
            otpCache[key] = otp;
        }

        public void RemoveOtp(string key)
        {
            otpCache.TryRemove(key, out _);
        }
    }
}
