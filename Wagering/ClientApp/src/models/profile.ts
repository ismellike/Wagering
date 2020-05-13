interface Profile {
    id?: string;
    displayName?: string;
    isVerified?: boolean;
    publicKey?: string | null;
    platform?: string | null;
    input?: string | null;
    ratings?: Rating[];
    notifications?: PersonalNotification[];
    userGroups?: UserGroup[];
}
