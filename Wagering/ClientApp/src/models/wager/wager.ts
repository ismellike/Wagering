interface Wager extends Group {
    hosts?: WagerHostBid[] | null;
    challenges?: WagerChallenge[] | null;
    minimumWager: number | null;
    maximumWager: number | null;
    challengeCount?: number;
    rules?: WagerRule[] | null;
    notifications?: WagerNotification[] | null;
}
