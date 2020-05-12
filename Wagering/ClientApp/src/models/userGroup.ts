interface UserGroup {
    id: number;
    userId: string;
    user?: ApplicationUser;
    wagerId?: number;
    wager?: Wager;
    groupName: string | null;
}
