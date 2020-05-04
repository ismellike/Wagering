interface WagerChallenge extends Approvable {
    id: number;
    wagerId: number;
    wager: Wager | null;
    challengers: WagerChallengeBid[] | null;
    date: Date;
    amount: number;
    isAccepted: boolean;
}
