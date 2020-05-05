interface Bid {
    id?: number;
    userId?: string;
    user?: ApplicationUser | null;
    approved?: boolean | null;
}
