interface Wager extends Group {
    hosts?: WagerHostBid[];
    challenges?: WagerChallenge[];
    minimumWager?: number | null;
    maximumWager?: number | null;
    challengeCount?: number;
    rules?: WagerRule[];
}
