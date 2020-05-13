interface UserGroup {
    id: number;
    userId: string;
    user?: Profile;
    wagerId?: number;
    wager?: Wager;
    groupName: string | null;
}
