interface Bid {
    id?: number;
    profileId?: string;
    profile?: Profile | null;
    approved?: boolean | null;
}
