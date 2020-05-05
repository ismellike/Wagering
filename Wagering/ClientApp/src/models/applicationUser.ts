interface ApplicationUser {
    id?: string;
    userName?: string;
    isVerified?: boolean;
    publicKey?: string;
    platform?: string;
    input?: string;
    ratings?: Rating[] | null;
}
