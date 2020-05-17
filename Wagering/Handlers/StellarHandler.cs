﻿using stellar_dotnet_sdk;

namespace Wagering.Handlers
{
    public static class StellarHandler
    {
        public static bool IsPublicKeyValid(string? publicKey)
        {
            return StrKey.IsValidEd25519PublicKey(publicKey);
        }
    }
}
